using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EgojitCms.web.TaoBaoKe;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EgojitCms.web.UI.Areas.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            IDictionary<string, string> param = new Dictionary<string, string>();
            param.Add("fields", "open_iid,title,nick,pic_url,price,commission,commission_rate,commission_num,commission_volume,seller_credit_score,item_location,volume");
            param.Add("keyword","保健品");
            string appkey = "test";

            string secret = "test";

            string session = "test";
            ViewBag.result = HttpHelper.Post("http://gw.api.tbsandbox.com/router/rest", appkey, secret, "taobao.atb.items.get",session, param);
            
            return View();
        }

        // GET: /<controller>/
        public IActionResult Test()
        {
            JsonResult result=new JsonResult(new {name="egojit",age=18});
            return result;
        }
    }
}
