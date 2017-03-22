using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class GestionDesembolsoRequest
    {

        [DataMember]
        public InformacionDesembolsoBO InformacionDesembolso { get; set; }

        [DataMember(IsRequired = true)]
        public string RutaActual { get; set; }
        [DataMember(IsRequired = true)]
        public string EtapaActual { get; set; }
        [DataMember(IsRequired = true)]
        public DateTime FechaNotificacion { get; set; }

        [DataMember]
        public InformacionEstacionBO InformacionEstacion { get; set; }


        private FirmaLegalizadoraBO firmaLegalizadora;
        [DataMember]
        public FirmaLegalizadoraBO FirmaLegalizadora
        {
            get
            {
                if (firmaLegalizadora == null)
                {
                    firmaLegalizadora = new FirmaLegalizadoraBO();
                }
                return firmaLegalizadora;
            }
            set { firmaLegalizadora = value; }
        }

    }
}
