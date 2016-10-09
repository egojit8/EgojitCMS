using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EgojitCms.web.BLL;
using EgojitCms.web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EgojitCms.web.UI.Controllers
{
    public class HomeController : Controller
    {
        private UserBLL userBll;
        public HomeController()
        {
            userBll = new UserBLL();
        }
        // GET: /<controller>/b
        public IActionResult Index()
        {
            User user = new User() {
                Id = Guid.NewGuid(),
                Name="高露",
                CreateAt=DateTime.Now
            };
            userBll.Add(user);
            ViewBag.result = "添加成功！";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
