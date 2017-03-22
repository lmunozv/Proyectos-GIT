using Business.TransformerLayer.Mapper;

using System.Collections.Generic;
using System.Data;


namespace Business.DataAccessLayer.Consultants
{
    public interface IGeneral<Persistent, BusinessObject>
    {        
        List<BusinessObject> ConsultarProcedimientoListObjArray(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter, MapperManager<Persistent, BusinessObject> mapper);
    }
}
