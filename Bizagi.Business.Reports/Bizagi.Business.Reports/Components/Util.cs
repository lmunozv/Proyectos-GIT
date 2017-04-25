using Bizagi.Business.Reports.Components.DAL;
using Bizagi.Business.Reports.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Bizagi.Business.Reports.Components
{
    public static class Util
    {
        #region Propiedades
        private static DataManager dal;
        private static DataManager Dal
        {
            get
            {
                if (dal == null)
                {
                    dal = new DataManager();
                }
                return dal;
            }
        }
        #endregion

        public static List<MenuBO> GetDashBoardMenu(object information)
        {
            MenuBO menu = new MenuBO();
            List<MenuBO> myMenu = (List<MenuBO>)information;
            var response = (from p in myMenu
                            where p.DashBoard == true
                            select p).ToList();

            return response;
        }

        public static MenuBO GetProcessChart(int idMenu, object information)
        {
            MenuBO menu = new MenuBO();
            List<MenuBO> myMenu= (List<MenuBO>)information;
            var response = (from p in myMenu
                            where p.Oid == idMenu
                            select p).ToList();
            if (response.Count > 0)
            {
                menu = response[0];
            }
            return menu;
        }

        /// <summary>
        /// Get List of All Menu Items from Database
        /// </summary>      
        /// <returns
        /// >Returns List<Menus> object</returns>
        public static List<MenuBO> GetInitialMenu(string roles)
        {
            try
            {
                List<MenuBO> listMenu = new List<MenuBO>();
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
            catch (Exception ex)
            {
                //Util.WriteEvent(ex.Message + "  " + ex.StackTrace);
                throw ex;
            }          
        }

        public static GridView AddGridView(DataTable detail)
        {
            GridView gv = new GridView();
            gv.DataSource = detail;
            gv.DataBind();
            return gv;
        }

        public static void WriteEvent(string sEvent)
        {
            
            string sSource;
            string sLog;
            sSource = "BizagiBusinessReports";
            sLog = "Application";             
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Error);           
        }

        public static object[] GetParameters(MenuBO menu)
        {
            object[] filter = new object[1] { menu.Oid };
            List<ParametersBO> lstParameters = Dal.GetParameters(filter);

            object[] parameters = new object[lstParameters.Count + 1];
            int control = 1;
            parameters[0] = menu.GraphicsType;

            foreach (var item in lstParameters)
            {
                parameters[control] = SetDataType(item);
                control++;
            }
            return parameters;
        }

        public static object SetDataType(ParametersBO parameter)
        {
            object response = new object();
            switch ((EnumDataType)parameter.DataType)
            {
                case EnumDataType.iInteger:
                    response = parameter.IValue;
                    break;
                case EnumDataType.sString:
                    response = parameter.SValue;
                    break;
                case EnumDataType.dDateTime:
                    response = parameter.DValue;
                    break;
                case EnumDataType.dDouble:
                    response = parameter.DoValue;
                    break;
                case EnumDataType.dDecimal:
                    response = parameter.CValue;
                    break;
                case EnumDataType.bBooean:
                    response = parameter.BValue;
                    break;
                default:
                    throw new Exception("Tipo de Dato No Implementado");
            }
            return response;
        }
    }
}