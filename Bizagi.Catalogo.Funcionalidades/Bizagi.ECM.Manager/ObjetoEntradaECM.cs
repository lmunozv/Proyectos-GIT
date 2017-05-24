using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.ECM.Manager
{
    public class ObjetoEntradaECM : ObjetoSalidaECM
    {
        public byte[] Base64String { get; set; }

        private Header header;
        public Header Header
        {
            get
            {
                if (header == null)
                {
                    header = new Header();
                }
                return header;
            }
            set
            {
                header = value;
            }
        }

        //public string Base64String { get; set; }

        public string Ext { get; set; }

        public string NombreDocumento { get; set; }

        public string Aplicacion { get; set; }

        public string Identificacion { get; set;}

        public string Login { get; set; }

        public string Tipo { get; set; }

        public string TipoIdentificacion { get; set; }

        public string Transaccion { get; set; }

        public string NombresApellidos { get; set; }

        private Trace trace;
        public Trace Trace
        {
            get
            {
                if (trace == null)
                {
                    trace = new Trace();
                }
                return trace;
            }
            set
            {
                trace = value;
            }
        }
    }
}
