using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgojitCms.web.Models
{
    /// <summary>
    /// 频道
    /// </summary>
    public class SysChannel
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 名称，唯一标识频道名称
        /// </summary>
        [MaxLength(20)]
        public String Name { get; set; }

        /// <summary>
        /// 标题，频道标题
        /// </summary>
        [MaxLength(40)]
        public String Title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Mark { get; set; }
    }
}
