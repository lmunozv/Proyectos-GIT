using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Models
{
    public class DataSeries
    {
        private Series serie;
        public Series Serie
        {
            get
            {
                if (serie == null)
                {
                    serie = new Series();
                }
                return serie;
            }

            set
            {
                serie = value;
            }
        }
    }
}