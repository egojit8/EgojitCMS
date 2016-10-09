using EgojitCms.web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgojitCms.web.Models
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

    }
}
