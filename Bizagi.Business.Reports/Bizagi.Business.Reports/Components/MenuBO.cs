using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Components
{
    public class MenuBO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        public MenuBO ParentID { get; set; }

        public int GraphicsType { get; set; }

        public string ProcedureName { get; set; }

        public string DataAxis { get; set; }

    }
}