using System.Collections.Generic;
using System.Data;

namespace Business.TransformerLayer.Mapper
{
    public interface IMapperManager<Persistent, BusinessObject>
    {
        #region Reader
        BusinessObject MappearReader2BO(DataSet dtTable);
        List<BusinessObject> MappearReader2ListBO(DataSet dtSet);
        BusinessObjectX MappearReader2BOX<BusinessObjectX>(DataTable dtTable);
        List<BusinessObjectX> MappearReader2ListBOX<BusinessObjectX>(DataTable dtTable);
        #endregion

        #region XPO
        BusinessObject MapperPersistent2BO(Persistent oObject);
        BusinessObject MapperBO2BO(BusinessObject oObject);
        #endregion



    }
}
