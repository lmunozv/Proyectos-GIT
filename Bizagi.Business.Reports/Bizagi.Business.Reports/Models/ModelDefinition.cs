using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Models
{
    public class ModelDefinition
    {
        Highcharts model;
        public Highcharts Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        DataTable detail;
        public DataTable Detail
        {
            get
            {
                return detail;
            }

            set
            {
                detail = value;
            }
        }

        public string Name { get; set; }

        public bool isDetail { get; set; }
        
    }
}