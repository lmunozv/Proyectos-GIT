using Bizagi.Business.Reports.TransformerLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Bizagi.Business.Reports.TransformerLayer
{
    public class StringTransformation : MapperManager<object, string>
    {
        public override List<string> MappearReader2ListBO(DataTable dtTable)
        {
            List<string> listResponse = new List<string>();
            foreach (DataRow item in dtTable.Rows)
            {
                listResponse.Add(item[2].ToString());
            }
            return listResponse;
        }
    }
}