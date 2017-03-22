using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class ErrorSistemaBO
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}
