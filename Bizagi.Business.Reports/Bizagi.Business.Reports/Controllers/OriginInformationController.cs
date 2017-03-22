using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Components.DAL;
using Bizagi.Business.Reports.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Bizagi.Business.Reports.Controllers
{
    public class OriginInformationController : Controller
    {
       
        public ActionResult Details(MenuBO menu)
        {
            GridView gv = new GridView();
            var model = GetDatellesDs(menu);
            gv.DataSource = model;
            gv.DataBind();
            Session["Cars"] = gv;
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

        private DataTable GetDatellesDs(MenuBO menu)
        {
            DataManager dal = new Components.DAL.DataManager();
            object[] parameter = new object[1] { menu.GraphicsType };
            var ds = dal.GetDetails(menu.ProcedureName, parameter);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        private List<InformacionDetalle> GetDatelles(MenuBO menu)
        {
            DataManager dal = new Components.DAL.DataManager();
            object[] parameter = new object[1] { menu.GraphicsType };
            var ds = dal.GetDetails(menu.ProcedureName, parameter);
            InformacionDetalle detalles = new InformacionDetalle();
            List<InformacionDetalle> listDetalles = new List<Models.InformacionDetalle>();
            if (ds.Tables.Count > 0)
            {
                DataTable datos = ds.Tables[0];
                foreach (DataRow item in datos.Rows)
                {
                    detalles.Id = item[0].ToString();
                    detalles.Campo = item[1].ToString();
                    var results = from myRow in ds.Tables[1].AsEnumerable()
                                  where myRow.Field<string>("Id") == detalles.Id
                                  select myRow;
                    foreach (DataRow itemDatos in results)
                    {
                        detalles.Valor = itemDatos[1].ToString();
                    }
                    listDetalles.Add(detalles);
                }               
            }
            return listDetalles;
        }
    }
}
