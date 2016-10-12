
using System.Linq;
using System.Threading.Tasks;
using EgojitCms.web.Models;
using System;


namespace EgojitCms.web.DAL
{
    public class WebSiteInfoDAL
    {
        private EgojitCmsDbContext dbContext;

        public  WebSiteInfoDAL()
        {
            this.dbContext = new EgojitCmsDbContext();
        }



        public int Add(WebSiteInfo model) {
            try
            {
                this.dbContext.WebSiteInfos.Add(model);
                return this.dbContext.SaveChanges();
            }
            catch (Exception ex) {
                System.Console.WriteLine(ex.ToString());
                return 0;
            }            
        }


    }
}
