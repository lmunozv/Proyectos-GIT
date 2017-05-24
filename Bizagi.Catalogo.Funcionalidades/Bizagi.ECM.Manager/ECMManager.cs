using Bizagi.ECM.Manager.InterfaceHub;
using Bizagi.ECM.Manager.Serializar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizagi.ECM.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class ECMManager
    {        
        #region Manager
        /// <summary>
        /// Metodo que permite ejecutar las operaciones en el gestor documental
        /// </summary>
        /// <param name="obj">Objeto que contiene la información para el ECM</param>
        /// <param name="operacion">Identificador de la operación</param>
        /// <returns>objeto que posee la información del número de radicado
        /// y el identificador del documento</returns>
        public List<ObjetoSalidaECM> EjecutarECM(ObjetoEntradaECM obj, int operacion)
        {
            List<ObjetoSalidaECM> lst = new List<Manager.ObjetoSalidaECM>();
            try
            {                
                var respuesta = new ObjetoSalidaECM();
                #region Trace
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ObjetoEntradaECM>(obj);
                    CrearArchivo(obj, "EntradaBizagi_ECM", respuestaObj);
                }
                #endregion                
                switch ((EnumOperacion)operacion)
                {
                    case EnumOperacion.Crear:                        
                        lst.Add(Hub.CrearDocumento(obj));
                        return lst;                       
                    case EnumOperacion.Actualizar:
                        lst.Add(Hub.ActualizarDocumento(obj));
                        return lst;
                    case EnumOperacion.Obtener:
                        return Hub.ConsultarDocumentos(obj);
                    case EnumOperacion.Eliminar:
                        lst.Add(Hub.EliminarDocumento(obj));
                        return lst;
                    default:
                        throw new Exception("Operación no implementada: " + operacion);                        
                }               
            }
            catch (Exception ex)
            {
                CrearArchivo(obj, "Mensaje Error", ex.Message);
                return lst;
            }
        }

        public string GenerarRadicado(ObjetoEntradaRadicado obj)
        {
            try
            {
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ObjetoEntradaRadicado>(obj);
                    CrearArchivo(obj, "EntradaBizagi_ECM", respuestaObj);
                }
                return Hub.CrearRegistroFormulario(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AdjuntarArchivoRadicado(ObjetoEntradaRadicado obj)
        {

            try
            {
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ObjetoEntradaRadicado>(obj);
                    CrearArchivo(obj, "EntradaBizagi_ECM", respuestaObj);
                }
                return Hub.AdjuntarArchivoRadicado(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion      

        #region Archivo
        internal static void CrearArchivo(ObjetoEntradaECM obj, string nombreRegla, string informacion)
        {
            // Write the string to a file.    
            string info = obj.Trace.UrlTrace + obj.Trace.NombreProceso + "--" + nombreRegla + "-- Caso # " + obj.Trace.NumeroSolicitud+".txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(info);
            file.WriteLine(informacion);
            file.Close();
        }

        internal static void CrearArchivo(ObjetoEntradaRadicado obj, string nombreRegla, string informacion)
        {
            // Write the string to a file.    
            string info = obj.Trace.UrlTrace + obj.Trace.NombreProceso + "--" + nombreRegla + "-- Caso # " + obj.Trace.NumeroSolicitud + ".txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(info);
            file.WriteLine(informacion);
            file.Close();
        }
        #endregion
    }

    enum EnumOperacion
    {
        Crear=1,
        Actualizar = 2,
        Obtener = 3,
        Eliminar = 4
    }
}
