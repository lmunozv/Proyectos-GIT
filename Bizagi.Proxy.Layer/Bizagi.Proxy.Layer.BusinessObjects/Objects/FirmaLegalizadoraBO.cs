﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class FirmaLegalizadoraBO
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }
    }
}
