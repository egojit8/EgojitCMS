using EgojitCms.web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgojitCms
{
    public class EgojitCmsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(@"Server=localhost;database=cms;uid=root;pwd=egojit;");
            //optionsBuilder.UseSqlite("Filename=./egojitcms.db");
        }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// 网站信息
        /// </summary>
        public DbSet<WebSiteInfo> WebSiteInfos { get; set; }

         /// <summary>
        /// 频道信息
        /// </summary>
        public DbSet<SysChannel> Channels { get; set; }

    }
}
