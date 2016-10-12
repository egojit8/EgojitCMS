

using System;
using System.ComponentModel.DataAnnotations;

namespace EgojitCms.web.Models
{


    public class WebSiteInfo
    {

        public Guid Id { get; set; }


        /// <summary>
        /// 网站名称
        /// </summary>
        [MaxLength(40)]
        public String WebName{get;set;}



        /// <summary>
        /// 网站关键词
        /// </summary>
        [MaxLength(80)]
        public String WebKey{get;set;}

         /// <summary>
        /// 网站描述
        /// </summary>
        [MaxLength(140)]
        public String WebDesc{get;set;}

    }
}