using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.Proxy.Layer.BusinessObjects.Messages
{
    public enum CodigoRespuesta
    {
        Exitosa = 0,
        ErrorComunicacion = 1,
        ErrorEstructura = 2,
        InformacionNoEncontrada = 3,
        ErrorBizagi = 4,
        ErrorTecnico = 5

    }
}
