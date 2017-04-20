using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Models
{
    public class ChartsModel
    {
        private ModelDefinition modelDef1;
        public ModelDefinition ModelDef1
        {
            get
            {
                if (modelDef1 == null)
                {
                    modelDef1 = new ModelDefinition();
                }
                return modelDef1;
            }
            set
            {
                modelDef1 = value;
            }
        }

        private ModelDefinition modelDef2;
        public ModelDefinition ModelDef2
        {
            get
            {
                if (modelDef2 == null)
                {
                    modelDef2 = new ModelDefinition();
                }
                return modelDef2;
            }
            set
            {
                modelDef2 = value;
            }
        }

        private ModelDefinition modelDef3;
        public ModelDefinition ModelDef3
        {
            get
            {
                if (modelDef3 == null)
                {
                    modelDef3 = new ModelDefinition();
                }
                return modelDef3;
            }
            set
            {
                modelDef3 = value;
            }
        }

        private ModelDefinition modelDef4;
        public ModelDefinition ModelDef4
        {
            get
            {
                if (modelDef4 == null)
                {
                    modelDef4 = new ModelDefinition();
                }
                return modelDef4;
            }
            set
            {
                modelDef4 = value;
            }
        }
    }
}