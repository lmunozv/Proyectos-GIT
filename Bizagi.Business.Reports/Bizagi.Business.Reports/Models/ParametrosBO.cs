using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Models
{
    public class ParametersBO
    {
        #region Values
        public string SValue { get; set; }

        public bool BValue { get; set; }

        public double DoValue { get; set; }

        public DateTime DValue { get; set; }

        public int IValue { get; set; }

        public decimal CValue { get; set; }
        #endregion

        public int Orden { get; set; }
        
        public int DataType { get; set; }
            
    }
}