using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Models;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Bizagi.Business.Reports.Controllers
{
    
    public class GraphicController : Controller
    {

        /// <summary>
        /// Ccontrolador grafico que permite mostrar
        /// la información de negocio de bizagi
        /// </summary>        
        public ActionResult Details(Int32 id)
        {
            MenuBO menu = Util.GetProcessChart(id, Session["myMenu"]);                   
            Highcharts chart = Grapher.GetGraphic(menu);       
            Response.AddHeader("Refresh", ConfigurationManager.AppSettings["Refresh"]);
            return View(chart);
        }
    }
}
