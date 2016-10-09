using EgojitCms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgojitCms.web.DAL
{

    
    public class UserDAL
    {
        private EgojitCmsDbContext dbContext;

        public  UserDAL()
        {
            this.dbContext = new EgojitCmsDbContext();
        }



        public int Add(User user) {
            try
            {
                this.dbContext.Users.Add(user);
                return this.dbContext.SaveChanges();

            }
            catch (Exception ex) {
                System.Console.WriteLine(ex.ToString());
                return 0;
            }
            
        }
    }
}
