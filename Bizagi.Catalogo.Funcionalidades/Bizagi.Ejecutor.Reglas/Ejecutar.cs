using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Bizagi.Ejecutor.Reglas
{
    public class Ejecutar
    {
        public object MethodRuleEjecutor(string clase, string nSpace_Clase, string metodo, ArrayList argumentos)
        { 
          return RuleManager.MethodRuleEjecutor(clase, nSpace_Clase, metodo, GetArguments(argumentos));        
        }

        private object[] GetArguments(ArrayList argumentos)
        {
            object[] response = new object[argumentos.Count];
            int x = 0;
            foreach (var item in argumentos)
            {
                response[x] = item;
            }

            return response;
        }

        private ReglaBO ObtenerRegla(string clase)
        {
            ReglaBO regla = new ReglaBO();
            string nombreClase = string.Empty;
            string met = string.Empty;
            string cs = string.Empty;
            string nameSpace = string.Empty;
            cs = @"using System;
                                using System.Collections.Generic;
                                using System.Text;  
                                using System.Diagnostics;                              
                                namespace Bizagi.Ejecutor.Reglas
                                {
                                  @reg
                                };".Replace("@reg", clase.ToString());
            nameSpace = "Bizagi.Ejecutor.Reglas." + nombreClase;
            regla.CS = cs;
            regla.Metodo = met;
            regla.NameSpace = nameSpace;
            return regla;
        }
    }

    

    public class ReglaBO
    {
        public string Metodo { get; set; }
        public string CS { get; set; }
        public string NameSpace { get; set; }
    }
}
