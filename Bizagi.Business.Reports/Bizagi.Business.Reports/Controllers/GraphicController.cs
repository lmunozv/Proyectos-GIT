using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Models;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bizagi.Business.Reports.Controllers
{
    public class GraphicController : Controller
    {    
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Details(MenuBO menu)
        {
            ChartTypes chartType = (ChartTypes)menu.GraphicsType;
            Highcharts chart = Grapher.GetGraphic(menu);            
            return View(chart);
        }
       
    }
}
