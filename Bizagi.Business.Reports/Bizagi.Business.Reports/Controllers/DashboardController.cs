using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Models;
using DotNet.Highcharts;
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
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Child-Only
        /// <summary>
        /// Presenta la información detalle
        /// </summary>
        /// <returns></returns>
        public ActionResult DashBoard()
        {
            List<MenuBO> myMenu =Util.GetDashBoardMenu(Session["myMenu"]);
            var charts = new ChartsModel();
            int cont = 0;
            foreach (var item in myMenu)
            {
                charts = GetChartsModel(charts, item, cont);
                cont++;
            }           
            Response.AddHeader("Refresh", ConfigurationManager.AppSettings["Refresh"]);
            return View(charts);
        }

        public ActionResult Download1()
        {
            if (Session["Cars1"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Cars1"], "Detalles.xls");
            }
            else
            {
                return new JavaScriptResult();
            }
        }

        public ActionResult Download2()
        {
            if (Session["Cars2"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Cars2"], "Detalles.xls");
            }
            else
            {
                return new JavaScriptResult();
            }
        }

        public ActionResult Download3()
        {
            if (Session["Cars3"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Cars3"], "Detalles.xls");
            }
            else
            {
                return new JavaScriptResult();
            }
        }

        public ActionResult Download4()
        {
            if (Session["Cars4"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Cars4"], "Detalles.xls");
            }
            else
            {
                return new JavaScriptResult();
            }
        }
        #endregion

        #region Privados     

        private ChartsModel GetChartsModel(ChartsModel model, MenuBO item, int indexx)
        {
            if (indexx == 0)
            {
                if (item.GraphicsType != 18)
                {
                    model.ModelDef1.Name = item.Title;
                    model.ModelDef1.Model = Grapher.GetGraphic(item);
                    model.ModelDef1.isDetail = false;
                }
                else
                {
                    model.ModelDef1.Name = item.Title;
                    model.ModelDef1.Detail = Grapher.GetDatatailsDs(item);
                    model.ModelDef1.isDetail = true;
                    Session["Cars1"] = Util.AddGridView(model.ModelDef1.Detail);
                }
            }
            else if (indexx == 1)
            {
                if (item.GraphicsType != 18)
                {
                    model.ModelDef2.Name = item.Title;
                    model.ModelDef2.Model = Grapher.GetGraphic(item);
                    model.ModelDef2.isDetail = false;
                }
                else
                {
                    model.ModelDef2.Name = item.Title;
                    model.ModelDef2.Detail = Grapher.GetDatatailsDs(item);
                    model.ModelDef2.isDetail = true;
                    Session["Cars2"] = Util.AddGridView(model.ModelDef2.Detail);
                }
            }
            else if (indexx == 2)
            {
                if (item.GraphicsType != 18)
                {
                    model.ModelDef3.Name = item.Title;
                    model.ModelDef3.Model = Grapher.GetGraphic(item);
                    model.ModelDef3.isDetail = false;
                }
                else
                {
                    model.ModelDef3.Name = item.Title;
                    model.ModelDef3.Detail = Grapher.GetDatatailsDs(item);
                    model.ModelDef3.isDetail = true;
                    Session["Cars3"] = Util.AddGridView(model.ModelDef3.Detail);
                }
            }
            else
            {
                if (item.GraphicsType != 18)
                {
                    model.ModelDef4.Name = item.Title;
                    model.ModelDef4.Model = Grapher.GetGraphic(item);
                    model.ModelDef4.isDetail = false;
                }
                else
                {
                    model.ModelDef4.Name = item.Title;
                    model.ModelDef4.Detail = Grapher.GetDatatailsDs(item);
                    model.ModelDef4.isDetail = true;
                    Session["Cars4"] = Util.AddGridView(model.ModelDef4.Detail);
                }
            } 
            return model;
        }

    }


    #endregion
}
