using Bizagi.Business.Reports.Consultants.Factory;
using Bizagi.Business.Reports.Consultants.Helper;
using Bizagi.Business.Reports.TransformerLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bizagi.Business.Reports.Consultants.ADO
{
    public class ConsultantReader<Persistent, BusinessObject> : IConsultantReader<Persistent, BusinessObject>
    {
        #region SP
        string Get_ParametersSP = "Get_ParametersSPs_SP";


        #endregion

        #region Reader
        public DataSet ConsultarDatos(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter)
        {
            try
            {
                DataSet dt = new DataSet();                
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString))
                {
                    IConsultantReader<DataTable, DataTable> consultor = (IConsultantReader<DataTable, DataTable>)ConsultantFactory.Create<DataTable, DataTable>();

                    SqlCommand command = new SqlCommand(NombreProcedimiento, unit);
                    command.CommandType = tipoEjecucion;
                    if (parameter != null)
                    {
                        SqlHelper helper = new SqlHelper(nombreConexion);
                        command.Parameters.AddRange(helper.GetListParameters(NombreProcedimiento, parameter));
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    unit.Open();
                    adapter.Fill(dt);                   
                    dt.CreateDataReader().Close();
                    unit.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BusinessObject> ConsultarProcedimientoListObj(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, Persistent parameter, MapperManager<Persistent, BusinessObject> mapper)
        {
            try
            {
                DataSet dt = new DataSet();
                List<BusinessObject> listaSalida = Activator.CreateInstance<List<BusinessObject>>();
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString))
                {
                    IConsultantReader<DataTable, DataTable> consultor = (IConsultantReader<DataTable, DataTable>)ConsultantFactory.Create<DataTable, DataTable>();

                    SqlCommand command = new SqlCommand(NombreProcedimiento, unit);
                    command.CommandType = tipoEjecucion;
                    if (parameter != null)
                    {
                        SqlHelper helper = new SqlHelper(nombreConexion);
                        command.Parameters.AddRange(helper.GetListParameters<Persistent>(NombreProcedimiento, parameter));
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    unit.Open();
                    adapter.Fill(dt);
                    listaSalida.AddRange(mapper.MappearReader2ListBO(dt));
                    dt.CreateDataReader().Close();
                    unit.Close();
                }
                return listaSalida;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BusinessObject> ConsultarProcedimientoListObjArray(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter, MapperManager<Persistent, BusinessObject> mapper)
        {
            try
            {
                List<BusinessObject> listaSalida = Activator.CreateInstance<List<BusinessObject>>();
                DataSet dt = new DataSet();
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString))
                {
                    IConsultantReader<DataTable, DataTable> consultor =(IConsultantReader<DataTable, DataTable>)ConsultantFactory.Create<DataTable, DataTable>();
                    SqlCommand command = new SqlCommand(NombreProcedimiento, unit);
                    command.CommandType = tipoEjecucion;
                    if (parameter != null)
                    {
                        SqlHelper helper = new SqlHelper(nombreConexion);
                        command.Parameters.AddRange(helper.GetListParameters(NombreProcedimiento, parameter));
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    unit.Open();
                    adapter.Fill(dt);
                    listaSalida.AddRange(mapper.MappearReader2ListBO(dt));
                    dt.CreateDataReader().Close();
                    unit.Close();
                }
                return listaSalida;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BusinessObject ConsultarProcedimientoObj(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, Persistent parameter, MapperManager<Persistent, BusinessObject> mapper)
        {
            try
            {
                DataSet dt = new DataSet();
                BusinessObject salida = Activator.CreateInstance<BusinessObject>();
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString))
                {
                    IConsultantReader<DataTable, DataTable> consultor = (IConsultantReader<DataTable, DataTable>)ConsultantFactory.Create<DataTable, DataTable>();

                    SqlCommand command = new SqlCommand(NombreProcedimiento, unit);
                    command.CommandType = tipoEjecucion;

                    if (parameter != null)
                    {
                        SqlHelper helper = new SqlHelper(nombreConexion);
                        command.Parameters.AddRange(helper.GetListParameters<Persistent>(NombreProcedimiento, parameter));
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    unit.Open();
                    adapter.Fill(dt);
                    salida = mapper.MappearReader2BO(dt);
                    dt.CreateDataReader().Close();
                    unit.Close();
                }
                return salida;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BusinessObject ConsultarProcedimientoObjArray(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter, MapperManager<Persistent, BusinessObject> mapper)
        {
            try
            {
                DataSet dt = new DataSet();
                BusinessObject salida = Activator.CreateInstance<BusinessObject>();
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString))
                {
                    IConsultantReader<DataTable, DataTable> consultor = (IConsultantReader<DataTable, DataTable>)ConsultantFactory.Create<DataTable, DataTable>();
                    SqlCommand command = new SqlCommand(NombreProcedimiento, unit);
                    command.CommandType = tipoEjecucion;
                    if (parameter != null)
                    {
                        SqlHelper helper = new SqlHelper(nombreConexion);
                        command.Parameters.AddRange(helper.GetListParameters(NombreProcedimiento, parameter));
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    unit.Open();
                    adapter.Fill(dt);
                    salida = mapper.MappearReader2BO(dt);
                    dt.CreateDataReader().Close();
                    unit.Close();
                }
                return salida;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetParametersSP(string NombreProcedimiento, string nombreConexion)
        {
            try
            {
                SqlDataReader reader;
                DataTable dt = new DataTable();
                using (SqlConnection unit = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString))
                {
                    unit.Open();
                    using (SqlCommand cmd = new SqlCommand(Get_ParametersSP, unit))
                    {
                        SqlParameter param = new SqlParameter("@nameSP", SqlDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = NombreProcedimiento;
                        cmd.Parameters.Add(param);
                        cmd.CommandType = CommandType.StoredProcedure;
                        reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                    unit.Close();
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
