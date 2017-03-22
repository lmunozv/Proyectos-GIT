using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Bizagi.Proxy.Utils.Serializar
{
    public static class SerializerManager
    {
        #region Serializacion XML

        //Serializar a XML (UTF-16) un objeto cualquiera
        public static string SerializarToXml<T>(T obj)
        {
            try
            {
                StringWriter strWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(strWriter, obj);
                string resultXml = strWriter.ToString();
                strWriter.Close();
                return resultXml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SerializarToXml<T>(bool omitirDeclaracion, T obj)
        {
            try
            {
                StringWriter strWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = omitirDeclaracion };
                XmlWriter writer = XmlWriter.Create(strWriter, settings);
                serializer.Serialize(writer, obj);
                return strWriter.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SerializarToXmlTest<T>(T obj, Type[] extraTypes)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T), extraTypes);
                    serializer.Serialize(xmlWriter, obj);
                    xmlWriter.Flush();
                }

                return stringBuilder.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desererializa un xml
        /// </summary>
        /// <param name="xmlSerializado"></param>
        /// <returns></returns>
        public static T DeserializarTo<T>(string xmlSerializado)
        {
            try
            {
                XmlAttributeOverrides over = new XmlAttributeOverrides();
                XmlAttributes atr = new XmlAttributes();
                over.Add(typeof(T), atr);
                XmlSerializer xmlSerz = new XmlSerializer(typeof(T), over);
                using (StringReader strReader = new StringReader(xmlSerializado))
                {
                    object obj = xmlSerz.Deserialize(strReader);
                    return (T)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desererializa un xml
        /// </summary>
        /// <param name="xmlSerializado"></param>
        /// <returns></returns>
        public static T DeserializarTo2<T>(string xmlSerializado)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlSerializado)))
                {
                    reader.MoveToContent();
                    object obj = new XmlSerializer(typeof(T)).Deserialize(reader);
                    return (T)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desererializa un xml
        /// </summary>
        /// <param name="xmlSerializado"></param>
        /// <returns></returns>
        public static T DeserializarTo2<T>(string xmlSerializado, Type[] extraTypes)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlSerializado)))
                {
                    reader.MoveToContent();
                    object obj = new XmlSerializer(typeof(T), extraTypes).Deserialize(reader);
                    return (T)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desererializa un xml
        /// </summary>
        /// <param name="xmlSerializado"></param>
        /// <returns></returns>
        public static T DeserializarTo2Test<T>(string xmlSerializado, Type[] extraTypes)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlSerializado)))
                {
                    reader.MoveToContent();
                    XmlSerializer serializer = new XmlSerializer(typeof(T), extraTypes);
                    object obj = serializer.Deserialize(reader);
                    return (T)obj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T DeserializarXML<T>(MemoryStream Stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var objeto = (T)serializer.Deserialize(Stream);
            return objeto;
        }

        public static T DeserializarXMLS<T>(string mensaje)
        {
            T respuesta;
            using (MemoryStream Stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(mensaje)))
            {
                respuesta = DeserializarXML<T>(Stream);
            }
            return respuesta;
        }

        public static T DeserializarJSON<T>(string mensaje)
        {
            try
            {
                T respuesta = new JavaScriptSerializer().Deserialize<T>(mensaje);
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Serializacion XML      

        public static Type ObtenerTipo(string tipo)
        {
            if (tipo == "String")
            {
                return typeof(String);
            }
            else if (tipo == "Int")
            {
                return typeof(int);
            }
            else if (tipo == "Double")
            {
                return typeof(Double);
            }
            else if (tipo == "DateTime")
            {
                return typeof(DateTime);
            }
            else
            {
                throw new Exception("El tipo indicado no ha sido incluido en la fabrica");
            }
        }      
    }
}
