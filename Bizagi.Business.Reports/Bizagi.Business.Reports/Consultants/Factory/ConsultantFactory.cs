using Bizagi.Business.Reports.Consultants.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Consultants.Factory
{
    public class ConsultantFactory
    {
        public static IGeneral<Persistent, BusinessObject> Create<Persistent, BusinessObject>()
        {
            return new ConsultantReader<Persistent, BusinessObject>() as IConsultantReader<Persistent, BusinessObject>;
        }
    }
}