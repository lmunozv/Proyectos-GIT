using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bizagi.Business.Reports.TransformerLayer.Mapper
{
    public class MapperManager<Persistent, BusinessObject> : IMapperManager<Persistent, BusinessObject>
    {
        #region Transformar IDataReader
        public virtual BusinessObject MappearReader2BO(IDataReader reader)
        {
            try
            {
                // Se crea la lista que será la respuesta del método.                
                List<BusinessObject> respuesta = new List<BusinessObject>();
                BusinessObject instancia = (BusinessObject)Activator.CreateInstance<BusinessObject>();
                if (reader != null)
                {
                    // Si el lector tiene registros.
                    // Se obtienen las propiedades del objeto que llena la lista
                    PropertyInfo[] propiedades = typeof(BusinessObject).GetProperties();
                    // Se mapean las propiedades con los campos obtenidos.                 
                    // Para que el mapeo sea correcto, los campos obtenidos tienen               
                    // que coincidir en el nombre de la propiedad.              
                    Dictionary<string, int> ubicacion = new Dictionary<string, int>();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        for (int indice = 0; indice < reader.FieldCount; indice++)
                            if ((propiedad.Name == reader.GetName(indice))
                                && (propiedad.CanWrite))
                                ubicacion.Add(propiedad.Name, indice);
                    }
                    // Se recorren los registros del lector.             
                    while (reader.Read())
                    {
                        foreach (PropertyInfo propiedad in propiedades)
                        {
                            int columna = -1;
                            if (ubicacion.TryGetValue(propiedad.Name, out columna))
                            {
                                try
                                {
                                    if (!reader.IsDBNull(columna))
                                        propiedad.SetValue(instancia, reader.GetValue(columna), null);
                                }
                                catch { throw; }
                            }
                        }
                        respuesta.Add(instancia);
                    }
                }
                return instancia;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual BusinessObject MappearReader2BO(DataTable dtTable)
        {
            try
            {
                IDataReader reader = dtTable.CreateDataReader();
                return MappearReader2BO(reader);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual BusinessObject MappearReader2BO(DataSet dtSet)
        {
            try
            {
                BusinessObject obj = (BusinessObject)Activator.CreateInstance<BusinessObject>();
                foreach (DataTable item in dtSet.Tables)
                {
                    obj = MappearReader2BO(item);
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<BusinessObject> MappearReader2ListBO(DataSet dtSet)
        {
            try
            {
                List<BusinessObject> lst = (List<BusinessObject>)Activator.CreateInstance<List<BusinessObject>>();
                foreach (DataTable item in dtSet.Tables)
                {
                    lst.AddRange(MappearReader2ListBO(item));
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<BusinessObject> MappearReader2ListBO(DataTable dtTable)
        {
            try
            {
                // Se crea la lista que será la respuesta del método.                
                List<BusinessObject> respuesta = new List<BusinessObject>();
                IDataReader reader = dtTable.CreateDataReader();
                if (reader != null)
                {
                    // Si el lector tiene registros.
                    // Se obtienen las propiedades del objeto que llena la lista
                    PropertyInfo[] propiedades = typeof(BusinessObject).GetProperties();
                    // Se mapean las propiedades con los campos obtenidos.                 
                    // Para que el mapeo sea correcto, los campos obtenidos tienen               
                    // que coincidir en el nombre de la propiedad.              
                    Dictionary<string, int> ubicacion = new Dictionary<string, int>();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        for (int indice = 0; indice < reader.FieldCount; indice++)
                            if ((propiedad.Name == reader.GetName(indice))
                                && (propiedad.CanWrite))
                                ubicacion.Add(propiedad.Name, indice);
                    }

                    // Se recorren los registros del lector.             
                    while (reader.Read())
                    {
                        BusinessObject instancia = (BusinessObject)Activator.CreateInstance<BusinessObject>();
                        foreach (PropertyInfo propiedad in propiedades)
                        {
                            int columna = -1;
                            if (ubicacion.TryGetValue(propiedad.Name, out columna))
                            {
                                try
                                {
                                    if (!reader.IsDBNull(columna))
                                        propiedad.SetValue(instancia, reader.GetValue(columna), null);
                                }
                                catch { throw; }
                            }
                        }
                        respuesta.Add(instancia);
                    }
                }
                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual BusinessObjectX MappearReader2BOX<BusinessObjectX>(DataTable dtTable)
        {
            try
            {
                IDataReader reader = dtTable.CreateDataReader();
                // Se crea la lista que será la respuesta del método.                
                List<BusinessObjectX> respuesta = new List<BusinessObjectX>();
                BusinessObjectX instancia = (BusinessObjectX)Activator.CreateInstance<BusinessObjectX>();
                if (reader != null)
                {
                    // Si el lector tiene registros.
                    // Se obtienen las propiedades del objeto que llena la lista
                    PropertyInfo[] propiedades = typeof(BusinessObjectX).GetProperties();
                    // Se mapean las propiedades con los campos obtenidos.                 
                    // Para que el mapeo sea correcto, los campos obtenidos tienen               
                    // que coincidir en el nombre de la propiedad.              
                    Dictionary<string, int> ubicacion = new Dictionary<string, int>();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        for (int indice = 0; indice < reader.FieldCount; indice++)
                            if ((propiedad.Name == reader.GetName(indice))
                                && (propiedad.CanWrite))
                                ubicacion.Add(propiedad.Name, indice);
                    }

                    // Se recorren los registros del lector.             
                    while (reader.Read())
                    {
                        foreach (PropertyInfo propiedad in propiedades)
                        {
                            int columna = -1;
                            if (ubicacion.TryGetValue(propiedad.Name, out columna))
                            {
                                try
                                {
                                    if (!reader.IsDBNull(columna))
                                        propiedad.SetValue(instancia, reader.GetValue(columna), null);
                                }
                                catch { throw; }
                            }
                        }
                        respuesta.Add(instancia);
                    }

                }
                return instancia;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<BusinessObjectX> MappearReader2ListBOX<BusinessObjectX>(DataTable dtTable)
        {
            try
            {
                // Se crea la lista que será la respuesta del método.                
                List<BusinessObjectX> respuesta = new List<BusinessObjectX>();
                IDataReader reader = dtTable.CreateDataReader();
                if (reader != null)
                {
                    // Si el lector tiene registros.
                    // Se obtienen las propiedades del objeto que llena la lista
                    PropertyInfo[] propiedades = typeof(BusinessObjectX).GetProperties();
                    // Se mapean las propiedades con los campos obtenidos.                 
                    // Para que el mapeo sea correcto, los campos obtenidos tienen               
                    // que coincidir en el nombre de la propiedad.              
                    Dictionary<string, int> ubicacion = new Dictionary<string, int>();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        for (int indice = 0; indice < reader.FieldCount; indice++)
                            if ((propiedad.Name == reader.GetName(indice))
                                && (propiedad.CanWrite))
                                ubicacion.Add(propiedad.Name, indice);
                    }

                    // Se recorren los registros del lector.             
                    while (reader.Read())
                    {
                        BusinessObjectX instancia = (BusinessObjectX)Activator.CreateInstance<BusinessObjectX>();
                        foreach (PropertyInfo propiedad in propiedades)
                        {
                            int columna = -1;
                            if (ubicacion.TryGetValue(propiedad.Name, out columna))
                            {
                                try
                                {
                                    if (!reader.IsDBNull(columna))
                                        propiedad.SetValue(instancia, reader.GetValue(columna), null);
                                }
                                catch { throw; }
                            }
                        }
                        respuesta.Add(instancia);
                    }
                }
                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Private Methods
        private static bool IsPrimitive(Type t)
        {
            // TODO: put any type here that you consider as primitive as I didn't
            // quite understand what your definition of primitive type is
            return new[] {
            typeof(string),
            typeof(char),
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(ulong),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime),
            typeof(Boolean),
        }.Contains(t);
        }

        private bool IsList(PropertyInfo prop)
        {
            if (prop.PropertyType.FullName.Contains("List") || prop.PropertyType.FullName.Contains("XPCollection"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}