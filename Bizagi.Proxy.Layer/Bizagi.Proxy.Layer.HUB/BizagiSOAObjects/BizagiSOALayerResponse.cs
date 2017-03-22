using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.HUB.BizagiSOAObjects
{
    class BizagiSOALayerResponse
    {

        private string codRespuesta;
        private string msgRespuesta;
        private int idCaso;
        private string radNumber;

        public string CodRespuesta
        {
            get
            {
                return codRespuesta;
            }

            set
            {
                codRespuesta = value;
            }
        }

        public string MsgRespuesta
        {
            get
            {
                return msgRespuesta;
            }

            set
            {
                msgRespuesta = value;
            }
        }

        public int IdCaso
        {
            get
            {
                return idCaso;
            }

            set
            {
                idCaso = value;
            }
        }

        public string RadNumber
        {
            get
            {
                return radNumber;
            }

            set
            {
                radNumber = value;
            }
        }
    }
}
