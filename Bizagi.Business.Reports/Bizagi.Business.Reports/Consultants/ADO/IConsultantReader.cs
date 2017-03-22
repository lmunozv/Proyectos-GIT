using Bizagi.Business.Reports.TransformerLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bizagi.Business.Reports.Consultants.ADO
{
    /// <summary>
    /// Interfaz que determina los metodos CRUD para comunicación 
    /// con la base de datos
    /// </summary>
    /// <typeparam name="Persistent">Objeto de persistencia del ORM</typeparam>
    /// <typeparam name="BusinessObject">Objeto de negocio (BO)</typeparam>
    public interface IConsultantReader<Persistent, BusinessObject> : IGeneral<Persistent, BusinessObject>
    {
        #region Reader        
        List<BusinessObject> ConsultarProcedimientoListObj(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, Persistent parameter, MapperManager<Persistent, BusinessObject> mapper);
        BusinessObject ConsultarProcedimientoObj(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, Persistent parameter, MapperManager<Persistent, BusinessObject> mapper);        
        BusinessObject ConsultarProcedimientoObjArray(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter, MapperManager<Persistent, BusinessObject> mapper);
        DataTable GetParametersSP(string NombreProcedimiento, string nombreConexion);
        DataSet ConsultarDatos(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter);
        #endregion

        

    }
}
