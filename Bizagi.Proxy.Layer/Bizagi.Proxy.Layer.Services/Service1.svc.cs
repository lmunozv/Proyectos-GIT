using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Bizagi.Proxy.Layer.Services.ValidarReferenciaService2;
using System.ServiceModel.Description;

namespace Bizagi.Proxy.Layer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void TestConsumoHTTPS(validarexistencia_Input req)
        {


            ValidarReferenciaService2.Cliente_validarexistenciaPortTypeClient c = new Cliente_validarexistenciaPortTypeClient();

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            (se, cert, chain, sslerror) =>
            {
            return true;
            };

            c.ClientCredentials.UserName.UserName = "fna\\Curso1";
            c.ClientCredentials.UserName.Password = "Fondo2009";
            c.ValidarExistencia(req);
            //return null;
        }
    }
}
