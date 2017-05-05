using Bizagi.Proxy.Layer.HUB.CorreosSeguros;
using Bizagi.Proxy.Layer.HUB.FirmarDocumentos;
using Bizagi.Proxy.Layer.HUB.GenerarMinuta;
using Bizagi.Proxy.Layer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Service.Manager
{
    public class HUBManager
    {
        #region Propiedades
        static CorreoSeguroImpl2 seg;
        static CorreoSeguroImpl2 CorreoSeguro
        {
            get
            {
                if (seg == null)
                {
                    seg = new CorreoSeguroImpl2();
                }
                return seg;
            }
        }

        static FirmaDocumentosImpl2 firma;
        static FirmaDocumentosImpl2 Firma
        {
            get
            {
                if (firma == null)
                {
                    firma = new FirmaDocumentosImpl2();
                }
                return firma;
            }         
        }
        #endregion

        #region Metodos
        public static int GenerarMinuta(solicitudType solicitud)
        {
            return HubDocumentalImpl.GenerarMinuta(solicitud);
        }

        public static HUB.FirmarDocumentos.FirmaDocuementoClient.FirmarDocumentoRsType
            FirmarDocumento(HUB.FirmarDocumentos.FirmaDocuementoClient.firmarDocumento_Input input)
        {
            return Firma.FirmarDocumento(input);
        }

        public static HUB.CorreosSeguros.CorreoSeguroClient.EnviarCorreoSeguroRsType
            EnviarCorreoSeguro2(HUB.CorreosSeguros.CorreoSeguroClient.enviarCorreoSeguro_Input input)
        {
            return CorreoSeguro.EnviarCorreoSeguro(input);
        }
        #endregion
    }
}
