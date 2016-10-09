using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EgojitCms.web.Models
{
    public class User
    {
        
        public Guid Id { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [MaxLength(30)]
        public String Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(40)]
        public String Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(15)]
        public String Tel { get; set; }

        /// <summary>
        /// 手机1
        /// </summary>
        [MaxLength(15)]
        public String Tel1 { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }

        
    }
}
