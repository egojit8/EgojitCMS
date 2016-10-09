using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgojitCms.web.Models
{
    /// <summary>
    /// 登录账户
    /// </summary>
    public class Account
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [MaxLength(40)]
        public String Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(40)]
        public String Pwd { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; } 

        public User User { get; set; }
    }
}
