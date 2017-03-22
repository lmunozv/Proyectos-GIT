using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class AjustePNCSegurosRequest
    {
        private List<string> lstDocumentos;
        [DataMember]
        public List<string> LstDocumentos
        {
            get
            {
                return lstDocumentos;
            }
            set
            {
                lstDocumentos = value;
            }
        }

        [DataMember]
        public string NumeroSolicitud { get; set; }

        [DataMember]
        public string WorkItem { get; set; }

        [DataMember]
        public string ProcessId { get; set; }

    }
}
