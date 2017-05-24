using System;
using System.Collections.Generic;
using Bizagi.ECM.Manager.ECMService;
using Bizagi.ECM.Manager.Serializar;
using Bizagi.ECM.Manager.CorrespondenceService;

namespace Bizagi.ECM.Manager.InterfaceHub
{
    internal static class Hub
    {
        #region Properties
        static ApiClient ecmService;
        private static ApiClient EcmService
        {
            get
            {
                if (ecmService == null)
                {
                    ecmService = new ApiClient();
                }
                return ecmService;
            }
        }

        static WorkManagerApiClient correspondece;
        private static WorkManagerApiClient Correspondece
        {
            get
            {
                if (correspondece == null)
                {
                    correspondece = new WorkManagerApiClient();
                }
                return correspondece;
            }
        }
        #endregion

        #region Crear
        internal static ObjetoSalidaECM CrearDocumento(ObjetoEntradaECM obj)
        {
            try
            {
                ObjetoSalidaECM salida = new Manager.ObjetoSalidaECM();

                #region Request
                ECMService.RequestDtoOfGestorDtopCDoQcXC rq = new ECMService.RequestDtoOfGestorDtopCDoQcXC();

                #region File
                ECMService.FileDto file = new ECMService.FileDto();
                rq.Archivos = new List<ECMService.FileDto>();
                file.Base64String = Convert.ToBase64String(obj.Base64String);
                //file.Base64String = obj.Base64String;
                file.Ext = obj.Ext;
                file.Nombre = obj.NombreDocumento;
                file.CodigoTipoDocumental = obj.CodigoTipoDocumental;
                rq.Archivos.Add(file);
                #endregion

                #region Header
                rq.Header = new ECMService.HeaderDto();
                rq.Header.Token = obj.Header.Token;
                rq.Header.Usuario = obj.Header.Usuario;
                #endregion

                #region Data
                rq.Data = new GestorDto();
                rq.Data.Aplicacion = obj.Aplicacion;
                rq.Data.Identificacion = obj.Identificacion;
                rq.Data.Login = obj.Login;
                rq.Data.Tipo = obj.Tipo;
                rq.Data.TipoIdentificacion = obj.TipoIdentificacion;
                rq.Data.Transaccion = obj.Transaccion;
                rq.Data.NombresyApellidos = obj.NombresApellidos;
                #endregion

                ECMService.Gestor_InsertarRequest req = new ECMService.Gestor_InsertarRequest(rq);
                #endregion

                #region Trace Request                
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ECMService.Gestor_InsertarRequest>(req);
                    ECMManager.CrearArchivo(obj, "RequestCrear_ECM", respuestaObj);
                }
                #endregion

                var res = EcmService.Gestor_Insertar(req);

                #region Trace Response
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<Bizagi.ECM.Manager.ECMService.Gestor_InsertarResponse>(res);
                    ECMManager.CrearArchivo(obj, "ResponseCrear_ECM", respuestaObj);
                }
                #endregion

                if (res.Gestor_InsertarResult.Sucess)
                {
                    salida.NumeroDocumento = res.Gestor_InsertarResult.CodeFiles[0];
                    salida.NumeroRadicado = res.Gestor_InsertarResult.Results;
                    return salida;
                }
                else
                {
                    throw new Exception("Error : " + res.Gestor_InsertarResult.Message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static string CrearRegistroFormulario(ObjetoEntradaRadicado obj)
        {
            try
            {
                string radicado = string.Empty;
                #region Request

                CorrespondenceService.CreateRegistroFormularioRequest req = new CreateRegistroFormularioRequest();

                #region Header
                req.value = new FormulariosRequestPost();
                req.value.Header = new CorrespondenceService.HeaderDto();                
                req.value.Header.Token = obj.Header.Token;
                req.value.Header.Usuario = obj.Header.Usuario;
                #endregion

                #region Datos            
                req.value.ListadoFormularios = new List<ListadoFormulariosDtoPost>();             
                var formulario = new ListadoFormulariosDtoPost();
                formulario.Codigo = obj.CodigoFormulario;
                formulario.ListCampos = new List<Diccionario>();
                foreach (var item in obj.LstCampos)
                {
                    var dato = new  Diccionario();
                    dato.Campo = item.Columna;
                    dato.Valor = item.Valor;
                    formulario.ListCampos.Add(dato);
                }
                req.value.ListadoFormularios.Add(formulario);
                #endregion
                #endregion

                #region Trace Request                
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<CreateRegistroFormularioRequest>(req);
                    ECMManager.CrearArchivo(obj, "RequestCrear_ECM", respuestaObj);
                }
                #endregion

                var res = Correspondece.CreateRegistroFormulario(req);
                var respuestaBO = SerializerManager.DeserializarJSON<Respuesta>(res.CreateRegistroFormularioResult);

                #region Trace Response
                if (obj.Trace.ActivarTrace)
                {                  
                    ECMManager.CrearArchivo(obj, "ResponseCrear_Correspondencia", res.CreateRegistroFormularioResult);
                }
                #endregion
                if (respuestaBO.Radicados.Count > 0)
                {
                    radicado = respuestaBO.Radicados[0];
                }

                return radicado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static string AdjuntarArchivoRadicado(ObjetoEntradaRadicado obj)
        {
            try
            {
                #region Request

                AdjuntarArchivosPorRegistroFormularioRequest req = new AdjuntarArchivosPorRegistroFormularioRequest();
                #region Header
                req.value = new DocumentosRequestPost();
                req.value.Header = new CorrespondenceService.HeaderDto();
                req.value.Header.Token = obj.Header.Token;
                req.value.Header.Usuario = obj.Header.Usuario;
                #endregion

                #region Datos          
                req.value.CamposSelect = new CamposSelectDto();
                req.value.CamposSelect.CodigoTabla = obj.CodigoTabla;
                req.value.CamposSelect.Columnas = obj.Columnas;
                req.value.CamposSelect.Operador = obj.Operador;
                req.value.CamposSelect.Parametro = obj.Parametro;
                req.value.CamposSelect.Valor = obj.Valor;
                
                #region Documentos
                req.value.ListDocumetnos = new List<DocumentosDto>()
                    { new DocumentosDto()
                    { Archivo =obj.Documento,
                     //Archivo =Convert.ToBase64String(obj.Documento),
                      CodigoDirectorio = obj.CodigoDirectorio,
                      CodigoTipoDocumento = obj.CodigoTipoDocumento,
                      Extension = obj.Extension,
                      Nombre = obj.NombreDocumento} };

                #endregion

                #endregion

                #endregion

                #region Trace Request                
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<AdjuntarArchivosPorRegistroFormularioRequest>(req);
                    ECMManager.CrearArchivo(obj, "RequestCrear_ECM", respuestaObj);
                }
                #endregion             
               

                var res = Correspondece.AdjuntarArchivosPorRegistroFormulario(req);

                #region Trace Response
                if (obj.Trace.ActivarTrace)
                {                    
                    ECMManager.CrearArchivo(obj, "ResponseAdjuntar_Correspondencia", res.AdjuntarArchivosPorRegistroFormularioResult);
                }
                #endregion
                return res.AdjuntarArchivosPorRegistroFormularioResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        internal static ObjetoSalidaECM ActualizarDocumento(ObjetoEntradaECM obj)
        {
            try
            {
                ObjetoSalidaECM salida = new Manager.ObjetoSalidaECM();
                #region Request

                #region File
                FileDto file = new FileDto();
                //file.Base64String = Convert.ToBase64String(obj.Base64String);
                file.CodigoTipoDocumental = obj.CodigoTipoDocumental;
                file.Ext = obj.Ext;
                file.Nombre = obj.NombreDocumento;
                #endregion

                #region Header
                ECMService.HeaderDto header = new ECMService.HeaderDto();
                header.Token = obj.Header.Token;
                header.Usuario = obj.Header.Usuario;
                #endregion

                ECMService.Gestor_CambiarDocumentoRequest req
                    = new ECMService.Gestor_CambiarDocumentoRequest(header, obj.NumeroDocumento, file);
                #endregion

                #region Trace Request
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ECMService.Gestor_CambiarDocumentoRequest>(req);
                    ECMManager.CrearArchivo(obj, "RequestModificar_ECM", respuestaObj);
                }
                #endregion
                var res = EcmService.Gestor_CambiarDocumento(req);
                #region Trace Response
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<Bizagi.ECM.Manager.ECMService.Gestor_CambiarDocumentoResponse>(res);
                    ECMManager.CrearArchivo(obj, "ResponseModificar_ECM", respuestaObj);
                }
                #endregion
                if (res.Gestor_CambiarDocumentoResult.Sucess)
                {
                    salida.NumeroDocumento = res.Gestor_CambiarDocumentoResult.CodeFiles[0];
                    salida.NumeroRadicado = res.Gestor_CambiarDocumentoResult.Results;
                    return salida;
                }
                else
                {
                    throw new Exception("Error : " + res.Gestor_CambiarDocumentoResult.Message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Consultar
        internal static List<ObjetoSalidaECM> ConsultarDocumentos(ObjetoEntradaECM obj)
        {
            try
            {
                List<ObjetoSalidaECM> lstSalida = new List<ObjetoSalidaECM>();

                #region Request

                #region Header
                ECMService.HeaderDto header = new ECMService.HeaderDto();
                header.Token = obj.Header.Token;
                header.Usuario = obj.Header.Usuario;
                #endregion

                ECMService.Gestor_ConsultarDocumentoRequest req
                  = new ECMService.Gestor_ConsultarDocumentoRequest(header, obj.NumeroRadicado, obj.Identificacion);
                #endregion

                #region Trace Request
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ECMService.Gestor_ConsultarDocumentoRequest>(req);
                    ECMManager.CrearArchivo(obj, "RequestConsultar_ECM", respuestaObj);
                }
                #endregion
                var res = EcmService.Gestor_ConsultarDocumento(req);
                #region Trace Response
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<Bizagi.ECM.Manager.ECMService.Gestor_ConsultarDocumentoResponse>(res);
                    ECMManager.CrearArchivo(obj, "ResponseConsultar_ECM", respuestaObj);
                }
                #endregion
                if (res.Gestor_ConsultarDocumentoResult.Sucess)
                {
                    foreach (var item in res.Gestor_ConsultarDocumentoResult.Results)
                    {
                        foreach (var itemDoc in item.Documentos)
                        {
                            ObjetoSalidaECM oSalida = new ObjetoSalidaECM();
                            oSalida.NumeroDocumento = itemDoc.CodigoArchivo;
                            oSalida.CodigoTipoDocumental = itemDoc.CodigoDirectorio;
                            oSalida.NumeroRadicado = item.Radicado;
                            lstSalida.Add(oSalida);
                        }
                    }
                }
                else
                {
                    throw new Exception("Error : " + res.Gestor_ConsultarDocumentoResult.Message);
                }
                return lstSalida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Borrar
        internal static ObjetoSalidaECM EliminarDocumento(ObjetoEntradaECM obj)
        {
            try
            {
                ObjetoSalidaECM salida = new Manager.ObjetoSalidaECM();
                #region Request              

                #region Header
                ECMService.HeaderDto header = new ECMService.HeaderDto();
                header.Token = obj.Header.Token;
                header.Usuario = obj.Header.Usuario;
                #endregion

                ECMService.Gestor_EliminarDocumentoRequest req
                    = new ECMService.Gestor_EliminarDocumentoRequest(header, obj.NumeroDocumento, obj.NumeroRadicado);
                #endregion

                #region Trace Request
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ECMService.Gestor_EliminarDocumentoRequest>(req);
                    ECMManager.CrearArchivo(obj, "RequestEliminar_ECM", respuestaObj);
                }
                #endregion
                var res =  EcmService.Gestor_EliminarDocumento(req);
                #region Trace Response
                if (obj.Trace.ActivarTrace)
                {
                    var respuestaObj = SerializerManager.SerializarToXml<ECMService.Gestor_EliminarDocumentoResponse>(res);
                    ECMManager.CrearArchivo(obj, "ResponseEliminar_ECM", respuestaObj);
                }
                #endregion
                return salida;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }


    public class Respuesta
    {
        public List<string> Radicados { get; set; }

        public string Error { get; set; }

        public string ErrorDocumentos { get; set; }            
    }
}
