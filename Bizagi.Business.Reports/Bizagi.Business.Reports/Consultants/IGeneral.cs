using Bizagi.Business.Reports.TransformerLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Business.Reports.Consultants
{
    public interface IGeneral<Persistent, BusinessObject>
    {
        List<BusinessObject> ConsultarProcedimientoListObjArray(string NombreProcedimiento, string nombreConexion, CommandType tipoEjecucion, object[] parameter, MapperManager<Persistent, BusinessObject> mapper);
    }
}
