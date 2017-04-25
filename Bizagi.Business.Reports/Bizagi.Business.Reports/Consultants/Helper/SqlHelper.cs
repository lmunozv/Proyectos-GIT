﻿using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Components.DAL;
using Bizagi.Business.Reports.Consultants.ADO;
using Bizagi.Business.Reports.Consultants.Util;
using Bizagi.Business.Reports.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bizagi.Business.Reports.Consultants.Helper
{
    public class SqlHelper
    {
       

        #region Constructor
        public SqlHelper(string nombreConexion)
        {
            Conexion = nombreConexion;
        }
        #endregion

        #region Propiedades
        private string Conexion { get; set; }
        private static string GET_PARAMETERSINOUT_SP { get { return ConfigurationManager.AppSettings["SPParametros"]; } }
        #endregion

        #region METODOS

        /// <summary>
        /// Metodo que permite crear la lista de parametros para un SP
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public SqlParameter[] GetListParameters<Parameters>(string SP_NAME, Parameters parameter)
        {
            try
            {
                List<PropertyInfo> properties = typeof(Parameters).GetProperties().ToList();
                IConsultantReader<DataTable, DataTable> consultor = new ConsultantReader<DataTable, DataTable>();
                DataTable paramsSp = consultor.GetParametersSP(SP_NAME.Substring(SP_NAME.IndexOf(".") + 1), Conexion);
                SqlParameter[] listParameter = new SqlParameter[paramsSp.Rows.Count];
                Int32 i = 0;
                
                foreach (DataRow itemRow in paramsSp.Rows)
                {

                    SqlParameter parameterSQL;
                    var nameParameterSp = itemRow["name"].ToString();
                    var queryProperty =
                                     (from prop in properties
                                      where prop.Name.Equals(nameParameterSp.Replace("@", string.Empty))
                                      select prop).ToList();
                    if (queryProperty.Count > 0)
                    {
                        parameterSQL = new SqlParameter();
                        parameterSQL.ParameterName = nameParameterSp;
                        parameterSQL.Value = queryProperty[0].GetValue(parameter);
                        parameterSQL.Direction = ParameterDirection.Input;
                        listParameter[i] = parameterSQL;
                        i += 1;
                    }
                }
                if (listParameter.Contains(null))
                {
                    throw new Exception(string.Format(DALMessage.Error_Parametros, parameter.GetType(), SP_NAME));
                }
                return listParameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlParameter[] GetListParameters(string SP_NAME, object[] parameter)
        {
            try
            {
                IConsultantReader<DataTable, DataTable> consultor = new ConsultantReader<DataTable, DataTable>();
                DataTable paramsSp = consultor.GetParametersSP(SP_NAME.Substring(SP_NAME.IndexOf(".") + 1), Conexion);
                SqlParameter[] listParameter = new SqlParameter[paramsSp.Rows.Count];
                Int32 i = 0;
                ValidateParameters(parameter, listParameter, SP_NAME);
                foreach (DataRow itemRow in paramsSp.Rows)
                {
                    SqlParameter parameterSQL = new SqlParameter(); ;
                    var nameParameterSp = itemRow["name"].ToString();
                    parameterSQL.ParameterName = nameParameterSp;
                    parameterSQL.Value = parameter[i];
                    parameterSQL.Direction = ParameterDirection.Input;
                    listParameter[i] = parameterSQL;
                    i += 1;

                }
                return listParameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Privados
        private void ValidateParameters(object[] parameter, object[] listParameterSP, string spName)
        {
            if (parameter.Length < listParameterSP.Length)
            {
                throw new Exception(string.Format(DALMessage.Error_ParametrosCant, spName));
            }
        }      
        #endregion
    }
}