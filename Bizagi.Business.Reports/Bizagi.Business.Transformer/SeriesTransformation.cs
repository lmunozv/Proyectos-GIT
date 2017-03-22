using Bizagi.Business.BO;
using Business.TransformerLayer.Mapper;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Business.Transformer
{
    public class SeriesTransformation : MapperManager<object, Series>
    {
        public override Series MappearReader2BO(DataSet dtSet)
        {
            int x = 0;
            List<DetailDataBO> details = new List<DetailDataBO>();
            Series series = base.MappearReader2BO(dtSet.Tables[0]);
            object[] oData = null;
            details.AddRange(base.MappearReader2ListBOX<DetailDataBO>(dtSet.Tables[1]));
            oData = new object[details.Count];
            foreach (var item in details)
            {
                oData[x] = item.InformationData;
                x+=1;
            }
            series.Data = new Data(oData);
            return series;
        }
    }
}
