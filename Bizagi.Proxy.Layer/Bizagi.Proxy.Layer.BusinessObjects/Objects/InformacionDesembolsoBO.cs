 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class InformacionDesembolsoBO
    {


        
        [DataMember]
        public InformacionDeudorBO InformacionDeudor { get; set; }

        [DataMember(IsRequired = true)]
        public string NumeroTramite { get; set; }

        private FormaDesembolsoBO formaDesembolso;
        [DataMember]
        public FormaDesembolsoBO FormaDesembolso
        {
            get
            {
                if (formaDesembolso == null)
                {
                    formaDesembolso = new FormaDesembolsoBO();
                }
                return formaDesembolso;
            }
            set { formaDesembolso = value; }
        }


        [DataMember]
        public string NumeroOrdenPago { get; set; }

        private TipoEstadoBO estadoOrdenPago;
        [DataMember]
        public TipoEstadoBO EstadoOrdenPago
        {
            get
            {
                if (estadoOrdenPago == null)
                {
                    estadoOrdenPago = new TipoEstadoBO();
                }
                return estadoOrdenPago;
            }
            set { estadoOrdenPago = value; }
        }

        private TipoEstadoBO estadoTramite;
        [DataMember(IsRequired = true)]
        public TipoEstadoBO EstadoTramite
        {
            get
            {
                if (estadoTramite == null)
                {
                    estadoTramite = new TipoEstadoBO();
                }
                return estadoTramite;
            }
            set { estadoTramite = value; }
        }


        public CausalRechazoBO causalRechazTramite;
        [DataMember]
        public CausalRechazoBO CausalRechazoTramite
        {
            get
            {
                if (causalRechazTramite == null)
                {
                    causalRechazTramite = new CausalRechazoBO();
                }
                return causalRechazTramite;
            }
            set { causalRechazTramite = value; }
        }


       private List<CausalDevolucionBO> causalesDevolucion;
        [DataMember]
        public List<CausalDevolucionBO> CausalesDevolucion
        {
            get
            {
                if (causalesDevolucion == null)
                {
                    causalesDevolucion = new List<CausalDevolucionBO>();
                }
                return causalesDevolucion;
            }
            set { causalesDevolucion = value; }
        }

        [DataMember]
        public CausalReintegroBO CausalReintegro { get; set; }

        [DataMember]
        public double MontoDesembolso { get; set; }

    }
}
