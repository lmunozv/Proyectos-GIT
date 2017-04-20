using Bizagi.Business.Reports.Components;
using Bizagi.Business.Reports.Models;
using Bizagi.Business.Reports.TransformerLayer.Mapper;
using Bizagi.Business.Reports.TransformerLayer.Util;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Business.Reports.TransformerLayer.Factory
{
    public class FactoryTransformer
    {
        /// <summary>
        /// Metodo que crea las transformaciones
        /// de objetos
        /// </summary>
        /// <typeparam name="Persistent">Objeto de persistnecia</typeparam>
        /// <typeparam name="BusinessObject">Objeto de negocio "BO"</typeparam>
        /// <returns></returns>
        public static MapperManager<Persistent, BusinessObject> Create<Persistent, BusinessObject>()
        {
            Type modelType = typeof(BusinessObject);
            Type persistentType = typeof(Persistent);

            #region Consultas
            if (modelType == typeof(Series))
            {
                return new SeriesTransformation() as MapperManager<Persistent, BusinessObject>;
            }         
            if (modelType == typeof(MenuBO))
            {
                return new MenuTransformation() as MapperManager<Persistent, BusinessObject>;
            }
            if (modelType == typeof(LiteBO))
            {
                return new LiteTransformation() as MapperManager<Persistent, BusinessObject>;
            }
            if (modelType == typeof(GaugeBO))
            {
                return new GaugeTransformation() as MapperManager<Persistent, BusinessObject>;
            }
            if (modelType == typeof(string))
            {
                return new StringTransformation() as MapperManager<Persistent, BusinessObject>;
            }
            if (modelType == typeof(ParametersBO))
            {
                return new ParametersTransformation() as MapperManager<Persistent, BusinessObject>;
            }
            #endregion

            else
            {
                throw new Exception(string.Format(TransforMessage.Error_Factory, persistentType.Name));
            }
        }
    }
}
