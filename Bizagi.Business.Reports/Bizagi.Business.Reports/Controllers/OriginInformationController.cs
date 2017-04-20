using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Components.DAL;
using Bizagi.Business.Reports.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Bizagi.Business.Reports.Controllers
{
    public class OriginInformationController : Controller
    {       
        public ActionResult Details(Int32 id)
        {
            GridView gv = new GridView();
            MenuBO menu = Util.GetProcessChart(id, Session["myMenu"]);
            var model = Grapher.GetDatatailsDs(menu);
            gv.DataSource = model;
            gv.DataBind();
            Session["Cars"] = gv;
            Response.AddHeader("Refresh", ConfigurationManager.AppSettings["Refresh"]);
            return View(model);
        }

        public ActionResult Download()
        {
            if (Session["Cars"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Cars"], "Detalles.xls");
            }
            else
            {
                return new JavaScriptResult();
            }
        }      
    }
}
