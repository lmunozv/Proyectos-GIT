using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bizagi.Proxy.Layer.BusinessObjects.Messages;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class GestionDesembolsoResponse
    {
        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Mensaje { get; set; }


        private ErrorSistemaBO errorSistema;



       [DataMember]
        public int processId { get; set; }

        [DataMember]
        public string radNumber { get; set; }

        [DataMember]
        public ErrorSistemaBO ErrorSistema
        {
            get
            {
                if(this.errorSistema == null)
                    this.errorSistema = new  ErrorSistemaBO();
                return this.errorSistema;
            }

            set
            {
                this.errorSistema = value;
            }
        }
    }
}
