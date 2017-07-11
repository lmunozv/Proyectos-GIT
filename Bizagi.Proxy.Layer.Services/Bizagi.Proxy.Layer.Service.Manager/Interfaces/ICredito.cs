using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Service.Manager.Interfaces
{
    public interface ICredito
    {
        

        Cobis.ConsultarCargaTrabajo.Credito_ConsultarCargaTrabajo.consultarCargaTrabajoPorEtapa_Output
            consultarCargaTrabajo(Cobis.ConsultarCargaTrabajo.Credito_ConsultarCargaTrabajo.consultarCargaTrabajoPorEtapa_Input input);


        Bizagi.Proxy.Layer.Cobis.AsignarEstacionTramite.Credito_AsignarEstacionTramite.asignarEstacionTramite_Output
           asignarEstacionTramite(Bizagi.Proxy.Layer.Cobis.AsignarEstacionTramite.Credito_AsignarEstacionTramite.asignarEstacionTramite_Input input);
        
    }
}
