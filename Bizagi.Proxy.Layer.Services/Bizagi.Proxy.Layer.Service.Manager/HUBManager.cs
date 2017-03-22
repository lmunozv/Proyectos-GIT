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
        public static int GenerarMinuta(solicitudType solicitud)
        {
            return HubDocumentalImpl.GenerarMinuta(solicitud);
        }

        public static Bizagi.Proxy.Layer.HUB.FirmarDocumentos.Cliente_FirmaDigital.FirmarDocumentoRsType 
            FirmarDocumento(Bizagi.Proxy.Layer.HUB.FirmarDocumentos.Cliente_FirmaDigital.headerRq head, 
            Bizagi.Proxy.Layer.HUB.FirmarDocumentos.Cliente_FirmaDigital.FirmarDocumentoRqType body)
        {
            ProxyUtils.ByPassCertificate();
            FirmaDocumentosImpl ser = new FirmaDocumentosImpl();
            ser.headerRqValue = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLFirmaDigital");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.firmarDocumento(body);
        }

        public static Bizagi.Proxy.Layer.HUB.CorreosSeguros.Cliente_CorreoSeguro.EnviarCorreoSeguroRsType
            EnviarCorreoSeguro(Bizagi.Proxy.Layer.HUB.CorreosSeguros.Cliente_CorreoSeguro.headerRq head,
            Bizagi.Proxy.Layer.HUB.CorreosSeguros.Cliente_CorreoSeguro.EnviarCorreoSeguroRqType body)
        {
            ProxyUtils.ByPassCertificate();
            CorreoSeguroImpl ser = new CorreoSeguroImpl();
            ser.headerRqValue = head;
            ser.Url = ProxyUtils.GetServiceEndpoint("URLCorreoSeguro");
            NetworkCredential credential = ProxyUtils.getReceivedCredentials();
            //si no vienen credenciales basic, no se crea estructura de seguridad. 
            //sino, se genera excepción cuando hayan peticiones sin autenticación.
            if (credential != null)
            {
                ser.Credentials = credential;
                ser.PreAuthenticate = true;
            }
            return ser.enviarCorreoSeguro(body);
        }
    }
}
