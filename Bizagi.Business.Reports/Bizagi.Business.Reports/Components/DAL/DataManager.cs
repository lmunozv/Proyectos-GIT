using Bizagi.Business.Reports.Consultants.ADO;
using Bizagi.Business.Reports.TransformerLayer.Factory;
using Bizagi.Business.Reports.TransformerLayer.Mapper;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Components.DAL
{
    public class DataManager
    {
        public List<Series> GetData(string sp, object[] filter)
        {
            try
            {
                IConsultantReader<object, Series> consultor = new ConsultantReader<object, Series>();
                MapperManager<object, Series> mapper = FactoryTransformer.Create<object, Series>();
                List<Series> response =
                   consultor.ConsultarProcedimientoListObjArray(sp,
                                                             ConnectionString,
                                                             CommandType.StoredProcedure, filter, mapper);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MenuBO> GetMenu(object[] filter)
        {
            try
            {
                IConsultantReader<object, MenuBO> consultor = new ConsultantReader<object, MenuBO>();
                MapperManager<object, MenuBO> mapper = FactoryTransformer.Create<object, MenuBO>();
                List<MenuBO> response =
                   consultor.ConsultarProcedimientoListObjArray(MenuSp,
                                                             ConnectionString,
                                                             CommandType.StoredProcedure, filter, mapper);
                return response;
            }
            catch (Exception )
            {

                throw ;
            }
        }

        public GaugeBO GetGauge(string sp, object[] filter)
        {
            try
            {
                IConsultantReader<object, GaugeBO> consultor = new ConsultantReader<object, GaugeBO>();
                MapperManager<object, GaugeBO> mapper = FactoryTransformer.Create<object, GaugeBO>();
                GaugeBO response = consultor.ConsultarProcedimientoObjArray(sp,
                                                             ConnectionString,
                                                             CommandType.StoredProcedure, filter, mapper);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> GetAxis(string sp, object[] filter)
        {
            try
            {
                IConsultantReader<object, string> consultor = new ConsultantReader<object, string>();
                MapperManager<object, string> mapper = FactoryTransformer.Create<object, string>();
                List<string> response =
                   consultor.ConsultarProcedimientoListObjArray(sp,
                                                             ConnectionString,
                                                             CommandType.StoredProcedure, filter, mapper);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetDetails(string sp, object[] filter)
        {
            try
            {
                IConsultantReader<object, object> consultor = new ConsultantReader<object, object>();
                DataSet response =
                   consultor.ConsultarDatos(sp,ConnectionString,
                                               CommandType.StoredProcedure, filter);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #region Privados
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["EngineConnectionString"].Name;
            }
        }

        private static string MenuSp
        {
            get
            {
                return "Get_ChartMenu_SP";
            }
        }
        #endregion

    }
}