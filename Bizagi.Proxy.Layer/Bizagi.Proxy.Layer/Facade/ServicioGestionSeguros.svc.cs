using Bizagi.Proxy.Layer.BusinessObjects.Messages;
using Bizagi.Proxy.Layer.Manager.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bizagi.Proxy.Layer.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioGestionSeguros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioGestionSeguros.svc or ServicioGestionSeguros.svc.cs at the Solution Explorer and start debugging.
    public class ServicioGestionSeguros : IServicioGestionSeguros
    {
        public AjustePNCSegurosResponse AjustarPNCSeguros(AjustePNCSegurosRequest request)
        {
            ControladorReclamacionSeguros controlador = new ControladorReclamacionSeguros();
            return controlador.AjustarPNCSeguros(request);
        }
    }
}
