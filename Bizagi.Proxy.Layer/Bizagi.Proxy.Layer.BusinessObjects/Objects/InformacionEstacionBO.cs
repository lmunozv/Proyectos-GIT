using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    [DataContract]
    public class InformacionEstacionBO
    {

        [DataMember(IsRequired = true)]
        public string CodigoEstacion { get; set; }

        private TipoIdentificacionBO tipoIdentificacionEstacion;
        [DataMember(IsRequired = true)]
        public TipoIdentificacionBO TipoIdentificacionEstacion
        {
            get
            {
                if (tipoIdentificacionEstacion == null)
                {
                    tipoIdentificacionEstacion = new TipoIdentificacionBO();
                }
                return tipoIdentificacionEstacion;
            }
            set { tipoIdentificacionEstacion = value; }
        }

        [DataMember(IsRequired = true)]
        public string IdentificacionEstacion { get; set; }


        [DataMember(IsRequired = true)]
        public string DescripcionEstacion{ get; set; }
    }
}
