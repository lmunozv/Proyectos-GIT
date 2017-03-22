using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class InformacionDeudorBO
    {
        [DataMember(IsRequired = true)]
        public string NumeroIdentificacion { get; set; }

        [DataMember(IsRequired = true)]
        public TipoIdentificacionBO TipoIdentificacion{ get; set; }
    }
}
