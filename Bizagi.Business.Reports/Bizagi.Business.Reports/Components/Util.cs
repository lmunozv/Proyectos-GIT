using Bizagi.Business.Reports.Components.DAL;
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
    }
}