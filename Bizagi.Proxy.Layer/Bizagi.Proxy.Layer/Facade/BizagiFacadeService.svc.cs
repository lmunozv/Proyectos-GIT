using Bizagi.Proxy.Layer.BusinessObjects.Messages;
using Bizagi.Proxy.Layer.Manager.Controlador;
using Bizagi.Proxy.Layer.Manager.Desembolso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bizagi.Proxy.Layer.Desembolso
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioGestionDesembolso" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioGestionDesembolso.svc or ServicioGestionDesembolso.svc.cs at the Solution Explorer and start debugging.
    public class ServicioGestionDesembolso : IBizagiFacadeService
    {
        public GestionDesembolsoResponse NotificarEstadoDesembolso(GestionDesembolsoRequest NotificacionDesembolsoRequest)
        {
            ControladorGestionDesembolso manager = new ControladorGestionDesembolso();
            GestionDesembolsoResponse respuesta = manager.ProcesarSolicitud(NotificacionDesembolsoRequest);

            return respuesta;
        }

        
    }
}
