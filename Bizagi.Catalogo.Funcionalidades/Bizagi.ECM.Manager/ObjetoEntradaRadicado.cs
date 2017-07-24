using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.ECM.Manager
{
    public class ObjetoEntradaRadicado
    {
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

        #region Generar Radicado
        public string CodigoFormulario { get; set; }

        private List<Campo> lstCampos;
        public List<Campo> LstCampos
        {
            get
            {
                if (lstCampos == null)
                {
                    lstCampos = new List<Campo>();
                }
                return lstCampos;
            }
            set
            {
                lstCampos = value;
            }
        }
        #endregion

        #region Radicar Documento
        public string CodigoTabla { get; set; }

        public string Columnas { get; set; }

        public string Operador { get; set; }

        public string Parametro { get; set; }

        public string Valor { get; set; }

        #region Documento
        public byte[] Documento { get; set; }

        //public string Documento { get; set; }

        public string CodigoDirectorio { get; set; }

        public string CodigoTipoDocumento { get; set; }

        public string Extension { get; set; }

        public string NombreDocumento { get; set; }
        #endregion

        #endregion
    }

}
