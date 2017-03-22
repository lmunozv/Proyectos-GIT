using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Business.Reports.TransformerLayer.Mapper
{
    public interface IMapperManager<Persistent, BusinessObject>
    {
        #region Reader
        BusinessObject MappearReader2BO(DataSet dtTable);
        List<BusinessObject> MappearReader2ListBO(DataSet dtSet);
        BusinessObjectX MappearReader2BOX<BusinessObjectX>(DataTable dtTable);
        List<BusinessObjectX> MappearReader2ListBOX<BusinessObjectX>(DataTable dtTable);
        #endregion
    }
}
