using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace Bizagi.Test.Util
{
    public class Provider
    {
        public DataTable ConsultarSP(ArrayList parametros, string nombreSP)
        {
            try
            {
                SqlDataReader respuesta = null;
                
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
                {
                    unit.Open();

                    SqlCommand command = new SqlCommand(nombreSP, unit);
                    command.CommandType = CommandType.StoredProcedure;
                    #region Parametros
                    #region ConsultaParametros
                    SqlCommand commandParametros = new SqlCommand("Get_ProcedureParameters_SP", unit);
                    commandParametros.CommandType = CommandType.StoredProcedure;
                    SqlParameter parametro = new SqlParameter();
                    parametro.Direction = ParameterDirection.Input;
                    parametro.ParameterName = "@nameSP";
                    parametro.Value = nombreSP;
                    commandParametros.Parameters.Add(parametro);
                    respuesta = commandParametros.ExecuteReader();
                    DataTable dtParametro = new DataTable();
                    dtParametro.Load(respuesta);
                    #endregion
                    int cont = 0;
                    foreach (DataRow itemParametro in dtParametro.Rows)
                    {
                        SqlParameter parametroNegocio = new SqlParameter();
                        parametroNegocio.Direction = ParameterDirection.Input;
                        parametroNegocio.ParameterName = itemParametro[1].ToString();
                        parametroNegocio.Value = parametros[cont];
                        cont++;
                        command.Parameters.Add(parametroNegocio);
                    }
                    #endregion
                    respuesta = command.ExecuteReader();
                    DataTable tablaDatos = new DataTable();
                    tablaDatos.Load(respuesta);
                    unit.Close();
                    return tablaDatos;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 EjecutarSentencia(ArrayList parametros, string nombreSP)
        {
            try
            {
                Int32 numeroFilas = 0;
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
                {
                    unit.Open();

                    SqlCommand command = new SqlCommand(nombreSP, unit);
                    command.CommandType = CommandType.StoredProcedure;
                    #region Parametros
                    #region ConsultaParametros
                    SqlCommand commandParametros = new SqlCommand("Get_ProcedureParameters_SP", unit);
                    commandParametros.CommandType = CommandType.StoredProcedure;
                    SqlParameter parametro = new SqlParameter();
                    parametro.Direction = ParameterDirection.Input;
                    parametro.ParameterName = "@nameSP";
                    parametro.Value = nombreSP;
                    commandParametros.Parameters.Add(parametro);
                    SqlDataReader respuesta = commandParametros.ExecuteReader();
                    DataTable dtParametro = new DataTable();
                    dtParametro.Load(respuesta);
                    #endregion
                    int cont = 0;
                    foreach (DataRow itemParametro in dtParametro.Rows)
                    {
                        SqlParameter parametroNegocio = new SqlParameter();
                        parametroNegocio.Direction = ParameterDirection.Input;
                        parametroNegocio.ParameterName = itemParametro[1].ToString();
                        parametroNegocio.Value = parametros[cont];
                        cont++;
                        command.Parameters.Add(parametroNegocio);
                    }
                    #endregion
                    numeroFilas = command.ExecuteNonQuery();                   
                    unit.Close();
                    return numeroFilas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
   
}
