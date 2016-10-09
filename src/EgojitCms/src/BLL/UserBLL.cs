using EgojitCms.web.DAL;
using EgojitCms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgojitCms.web.BLL
{

    public class UserBLL
    {
        private UserDAL dal;
        public UserBLL()
        {
            this.dal = new UserDAL();
        }

        /// <summary>
        /// 添加用戶
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add(User user)
        {
            if (this.dal.Add(user) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
