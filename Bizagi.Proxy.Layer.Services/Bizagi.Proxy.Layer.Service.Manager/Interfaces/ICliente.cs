using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.Service.Manager.Interfaces
{
    public interface ICliente
    {
        Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia_WCF.validarexistencia_Output
           ValidarExistenciaCliente(Cobis.ValidarExistenciaCliente.Cliente_ValidarExistencia_WCF.validarexistencia_Input input);

        Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServicioResponse recuperarInfoBasicaPersonaJuridicaRequest(Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ConsumerHeader head, Cobis.RecuperarInfoPJ.Cliente_RecuperarInfoPJ.ServiceRequest body);

        Cobis.RecuperarInfoPN.ClientePersonaNaturalCliente.recuperarInfoBasica_Output
           RecuperarInfoBasicaPersonaNatural(Cobis.RecuperarInfoPN.ClientePersonaNaturalCliente.recuperarInfoBasica_Input input);

    }
}
