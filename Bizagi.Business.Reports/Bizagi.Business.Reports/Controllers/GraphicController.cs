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
    /// <summary>
    /// Ccontrolador grafico que permite mostrar
    /// la informacion de negocio de bizagi
    /// </summary>
    public class GraphicController : Controller
    {       
        public ActionResult Details(MenuBO menu)
        {
            ChartTypes chartType = (ChartTypes)menu.GraphicsType;
            Highcharts chart = Grapher.GetGraphic(menu);            
            return View(chart);
        }
       
    }
}
