using Bizagi.Business.Reports.Components.DAL;
using Bizagi.Business.Reports.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Components
{
    public static class MyMenu
    {
        /// <summary>
        /// Get List of All Menu Items from Database
        /// </summary>      
        /// <returns
        /// >Returns List<Menus> object</returns>
        public static List<MenuBO> GetMenus(string roles)
        {
            List<MenuBO> listMenu = new List<Components.MenuBO>();


            DataManager dal = new DAL.DataManager();
            object[] parameter;
            if (roles != string.Empty)
            {
                parameter = new object[1] { roles };
            }
            else
            {

                parameter = new object[1] { ConfigurationManager.AppSettings["DefaultRol"] };
            }
            listMenu = dal.GetMenu(parameter);

            return listMenu;
        }
    }
}