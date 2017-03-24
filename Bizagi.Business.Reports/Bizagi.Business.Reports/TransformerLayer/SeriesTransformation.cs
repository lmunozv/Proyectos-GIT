using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.TransformerLayer.Mapper;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Business.Reports.TransformerLayer
{
    public class SeriesTransformation : MapperManager<object, Series>
    {
        public override List<Series> MappearReader2ListBO(DataSet dtSet)
        {
            int x = 0;            
            object[] oData = null;
            List<DetailDataBO> details = new List<DetailDataBO>();
            List<Series> series = base.MappearReader2ListBO(dtSet.Tables[0]);
            details.AddRange(base.MappearReader2ListBOX<DetailDataBO>(dtSet.Tables[1]));
            
            foreach (var item in series)
            {
                var lDet = from det in details
                                       where det.Id == item.Id
                                       select det;
                oData = new object[lDet.Count()];
                x =0;
                foreach (var itemDet in lDet)
                {
                    oData[x] = itemDet.InformationData;
                    x += 1;
                }
                item.Data = new Data(oData);
            }  
            return series;
        }
    }
}
