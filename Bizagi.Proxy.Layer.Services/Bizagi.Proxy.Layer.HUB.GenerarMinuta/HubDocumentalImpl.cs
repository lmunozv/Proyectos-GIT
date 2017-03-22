using Bizagi.Proxy.Layer.HUB.GenerarMinuta.Cliente_HubDocumental;
using Bizagi.Proxy.Layer.Util;
using Bizagi.Proxy.Utils.Serializar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizagi.Proxy.Layer.HUB.GenerarMinuta
{
    public class HubDocumentalImpl
    {
        public static int GenerarMinuta(solicitudType solicitud)
        {
            try
            {
                string xml = SerializerManager.SerializarToXml<solicitudType>(solicitud);
                string mensaje = string.Empty;
                MigrarSolicitudRepartoPortTypeClient cliente = new Cliente_HubDocumental.MigrarSolicitudRepartoPortTypeClient();
                string base64 = ProxyUtils.GetBase64String(xml);               

                 var respuesta = cliente.MigrarSolicitudReparto(base64, out mensaje);

                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
