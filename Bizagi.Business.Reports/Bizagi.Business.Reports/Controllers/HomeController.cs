using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bizagi.Business.Reports.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(object[] oRoles)
        {
            string roles = string.Empty;
            int i = 0;
            foreach (var item in oRoles)
            {
                if(i==0)
                {
                    roles = item.ToString();
                    i+=1;
                }
                else
                {
                    roles = roles+"," +item.ToString();
                }                
            }

            Session["roles"] = roles;
            return View();
        }
        public ActionResult Index()
        {
            if(Convert.ToBoolean(ConfigurationManager.AppSettings["Debug"]))
            {
                Session["roles"] = "10019";
            }            
            return View();
        }
    }
}