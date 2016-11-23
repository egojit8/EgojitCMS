using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Net;
using System.Text.RegularExpressions;

namespace EgojitCms.web.TaoBaoKe
{
    public static class HttpHelper
    {

        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Encoding encoding = null)
        {
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetByteArrayAsync(url);
            var ret = encoding.GetString(data);
            return ret;
        }
        /// <summary>
        /// Http Get 同步方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Encoding encoding = null)
        {
            HttpClient httpClient = new HttpClient();
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var ret = encoding.GetString(t.Result);
            return ret;
        }

        /// <summary>
        /// POST 异步
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postStream"></param>
        /// <param name="encoding"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, Dictionary<string, string> formData = null, Encoding encoding = null, int timeOut = 10000)
        {

            HttpClientHandler handler = new HttpClientHandler();

            HttpClient client = new HttpClient(handler);
            MemoryStream ms = new MemoryStream();
            FillFormDataStream(formData, ms);//填充formData
            HttpContent hc = new StreamContent(ms);


            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
            hc.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36");
            hc.Headers.Add("Timeout", timeOut.ToString());
            hc.Headers.Add("KeepAlive", "true");

            var r = await client.PostAsync(url, hc);
            byte[] tmp = await r.Content.ReadAsByteArrayAsync();

            return encoding.GetString(tmp);
        }

        /// <summary>
        /// POST 同步
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postStream"></param>
        /// <param name="encoding"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static string HttpPost(string url, Dictionary<string, string> formData = null, Encoding encoding = null, int timeOut = 10000)
        {

            HttpClientHandler handler = new HttpClientHandler();

            HttpClient client = new HttpClient(handler);
            MemoryStream ms = new MemoryStream();
            FillFormDataStream(formData, ms);//填充formData
            HttpContent hc = new StreamContent(ms);


            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
            hc.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36");
            hc.Headers.Add("Timeout", timeOut.ToString());
            hc.Headers.Add("KeepAlive", "true");

            var t = client.PostAsync(url, hc);
            t.Wait();
            var t2 = t.Result.Content.ReadAsByteArrayAsync();
            return encoding.GetString(t2.Result);
        }

        /// <summary>
        /// 组装QueryString的方法
        /// 参数之间用&连接，首位没有符号，如：a=1&b=2&c=3
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string GetQueryString(this Dictionary<string, string> formData)
        {
            if (formData == null || formData.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            var i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 填充表单信息的Stream
        /// </summary>
        /// <param name="formData"></param>
        /// <param name="stream"></param>
        public static void FillFormDataStream(this Dictionary<string, string> formData, Stream stream)
        {
            string dataString = GetQueryString(formData);
            var formDataBytes = formData == null ? new byte[0] : Encoding.UTF8.GetBytes(dataString);
            stream.Write(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
        }












        /// <summary>

        /// 给TOP请求签名 API v2.0

        /// </summary>

        /// <param name="parameters">所有字符型的TOP请求参数</param>

        /// <param name="secret">签名密钥</param>

        /// <returns>签名</returns>

        private static string CreateSign(IDictionary<string, string> parameters, string secret)

        {

            parameters.Remove("sign");



            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);

            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();



            StringBuilder query = new StringBuilder(secret);

            while (dem.MoveNext())

            {

                string key = dem.Current.Key;

                string value = dem.Current.Value;

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))

                {

                    query.Append(key).Append(value);

                }

            }

            query.Append(secret);



            MD5 md5 = MD5.Create();

            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));



            StringBuilder result = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)

            {

                string hex = bytes[i].ToString("X");

                if (hex.Length == 1)

                {

                    result.Append("0");

                }

                result.Append(hex);

            }



            return result.ToString();

        }





        /// <summary>

        /// 组装普通文本请求参数。

        /// </summary>

        /// <param name="parameters">Key-Value形式请求参数字典</param>

        /// <returns>URL编码后的请求数据</returns>

        public static string PostData(IDictionary<string, string> parameters)

        {

            StringBuilder postData = new StringBuilder();

            bool hasParam = false;



            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();

            while (dem.MoveNext())

            {

                string name = dem.Current.Key;

                string value = dem.Current.Value;

                // 忽略参数名或参数值为空的参数

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))

                {

                    if (hasParam)

                    {

                        postData.Append("&");

                    }



                    postData.Append(name);

                    postData.Append("=");

                    postData.Append(Uri.EscapeDataString(value));

                    hasParam = true;

                }

            }



            return postData.ToString();

        }





        /// <summary>

        /// TOP API POST 请求

        /// </summary>

        /// <param name="url">请求容器URL</param>

        /// <param name="appkey">AppKey</param>

        /// <param name="appSecret">AppSecret</param>

        /// <param name="method">API接口方法名</param>

        /// <param name="session">调用私有的sessionkey</param>

        /// <param name="param">请求参数</param>

        /// <returns>返回字符串</returns>

        public static string Post(string url, string appkey, string appSecret, string method, string session,IDictionary<string, string> param)
        {
            
            #region -----API系统参数----
            param.Add("app_key", appkey);

            param.Add("method", method);

            param.Add("session", session);

            param.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            param.Add("format", "xml");

            param.Add("v", "2.0");

            param.Add("sign_method", "md5");

            param.Add("sign", CreateSign(param, appSecret));



            #endregion



            string result = string.Empty;



            #region ---- 完成 HTTP POST 请求----



            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            byte[] postData = Encoding.UTF8.GetBytes(PostData(param));

            Stream reqStream = req.GetRequestStreamAsync().Result;

            reqStream.Write(postData, 0, postData.Length);

            HttpWebResponse rsp = (HttpWebResponse)req.GetResponseAsync().Result;

            //Encoding encoding = Encoding.GetEncoding(Encoding.UTF8);

            Stream stream = null;

            StreamReader reader = null;

            stream = rsp.GetResponseStream();

            reader = new StreamReader(stream, Encoding.UTF8);

            result = reader.ReadToEnd();
            

            #endregion

            return Regex.Replace(result, @"[\x00-\x08\x0b-\x0c\x0e-\x1f]", "");

        }






    }
}
