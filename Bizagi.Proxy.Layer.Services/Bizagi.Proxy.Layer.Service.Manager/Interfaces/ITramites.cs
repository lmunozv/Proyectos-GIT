using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Service.Manager.Interfaces
{
    public interface ITramites
    {
        Cobis.RecuperarTramites.Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Output
            RecuperarTramites(Cobis.RecuperarTramites.Cliente_RecuperarTramite.consultarTramitesCreditoPorIdentificacion_Input input);

        Cobis.RecuperarDetalleTramite.Cliente_DetalleTramite.recuperarDetalleTramite_Output
           RecuperarDetalleTramite(Cobis.RecuperarDetalleTramite.Cliente_DetalleTramite.recuperarDetalleTramite_Input input);

        Bizagi.Proxy.Layer.Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Output 
            EnrutarTramiteCredito(Cobis.EnrutarTramiteCredito.Cobis_EnrutarTramite.enrutarTramiteCredito_Input input);
    }
}
