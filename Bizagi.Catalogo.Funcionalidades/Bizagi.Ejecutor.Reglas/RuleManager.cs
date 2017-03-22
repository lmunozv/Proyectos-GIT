using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;

namespace Bizagi.Ejecutor.Reglas
{
    public class RuleManager
    {
        public static object MethodRuleEjecutor(string clase, string nSpace_Clase, string metodo, object[] argumentos)
        {
            object objClase = Compiler(clase, nSpace_Clase);
            if (objClase.ToString().Contains("error"))
            {
                return objClase;
            }
            else
            {
                MethodInfo main;
                if (objClase.GetType().GetMethod(metodo).IsGenericMethod)
                {
                    Type[] argm = objClase.GetType().GetMethod(metodo).GetGenericArguments();
                    main = objClase.GetType().GetMethod(metodo).MakeGenericMethod(argm);
                    return main.Invoke(null, argumentos);
                }
                else
                {
                    main = objClase.GetType().GetMethod(metodo);
                    return main.Invoke(null, argumentos);
                }


                //return objClase.GetType().InvokeMember(metodo, BindingFlags.InvokeMethod, null, objClase, argumentos);
                //MethodInfo main = objClase.GetType().GetMethod(metodo);
                //return main.Invoke(null, null);
            }

        }


        public static object Compiler(string clase, string nSpace_Clase)
        {
            try
            {
                #region Parametros
                CompilerParameters objParametros = new CompilerParameters();
                //if (Convert.ToBoolean(ConfigurationManager.AppSettings["Debug"]))
                //{
                //    objParametros.GenerateInMemory = true;
                //    objParametros.IncludeDebugInformation = true;
                //}
                //else
                //{
                    objParametros.GenerateInMemory = false;
                    objParametros.IncludeDebugInformation = false;
                //}
                objParametros.GenerateExecutable = false;
                #endregion

                objParametros.TempFiles.KeepFiles = true;
                CodeDomProvider objCompiler = CodeDomProvider.CreateProvider("CSharp");
                //foreach (AssemblyName reference in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
                //{
                //    if (reference.Name.Contains("DevExpress"))
                //    {
                //        objParametros.ReferencedAssemblies.Add(ConfigurationManager.AppSettings["URL"] + reference.Name + ".dll");
                //    }
                //    else if (reference.Name.Contains("AutoMapper"))
                //    {
                //        objParametros.ReferencedAssemblies.Add(ConfigurationManager.AppSettings["URLMapper"] + reference.Name + ".dll");
                //    }
                //    else
                //    {
                //        objParametros.ReferencedAssemblies.Add(reference.Name + ".dll");
                //    }

                //}
                objParametros.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
                CompilerResults objResultados = objCompiler.CompileAssemblyFromSource(objParametros, clase);
                if (objResultados.Errors.HasErrors)
                {
                    StringBuilder sbError = new StringBuilder();
                    foreach (var item in objResultados.Errors)
                    {
                        sbError.Append(item);
                        sbError.Append("\n");
                    }
                    return sbError;
                }
                Assembly assembly = objResultados.CompiledAssembly;
                object objClase = objResultados.CompiledAssembly.CreateInstance(nSpace_Clase,
                    false, BindingFlags.CreateInstance, null, null, null, null);
                return objClase;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
