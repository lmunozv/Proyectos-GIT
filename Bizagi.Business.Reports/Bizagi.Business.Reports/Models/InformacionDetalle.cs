using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Models
{
    public class InformacionDetalle
    {
        public string Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Campo { get; set; }

        public string Valor { get; set; }

    }
}