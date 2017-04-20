using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Models
{
    public class GaugeBO
    {
        public double ObjectiveValue { get; set; }

        public double RealValue { get; set; }

        public double Range
        {
            get
            {
                return ObjectiveValue /3;
            }
        }

        public String Descripcion { get; set; }
  
    }
}