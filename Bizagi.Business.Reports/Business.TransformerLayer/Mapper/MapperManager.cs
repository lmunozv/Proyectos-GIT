using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Reflection;
using System.Data;


namespace Business.TransformerLayer.Mapper
{
    public abstract class MapperManager<Persistent, BusinessObject> : IMapperManager<Persistent, BusinessObject>
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

        #region Transformar XPO
        public virtual void AdditionalSettings(IMappingExpression<Persistent, BusinessObject> map, BusinessObject destination)
        {

        }

        public virtual void AdditionalSettings(IMappingExpression<BusinessObject, BusinessObject> map, BusinessObject destination)
        {

        }

        #region Transform Persistent to BusinessObjects
        /// <summary>
        /// Metoodo que mepea objetos de persistencia a BO
        /// </summary>
        /// <param name="oObject"></param>
        /// <returns></returns>
        public virtual BusinessObject MapperPersistent2BO(Persistent oObject)
        {
            try
            {
                Type t = typeof(BusinessObject);
                var map = AutoMapper.Mapper.CreateMap<Persistent, BusinessObject>();
                foreach (PropertyInfo prop in t.GetProperties())
                {
                    bool isPrimitive = IsPrimitive(prop.PropertyType);
                    bool isEnum = prop.PropertyType.IsEnum;
                    bool isList = IsList(prop);
                    if (!isPrimitive || isEnum && prop.CanRead && prop.CanWrite || isList)
                    {
                        map.ForMember(prop.Name, opt => opt.Ignore());
                    }
                }
                BusinessObject destination = (BusinessObject)Activator.CreateInstance<BusinessObject>();
                AdditionalSettings(map, destination);
                var customerViewItem = AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual BusinessObjectX MapperPersistent2BO<PersitentX, BusinessObjectX>(PersitentX oObject)
        {
            try
            {
                Type t = typeof(BusinessObjectX);
                var map = AutoMapper.Mapper.CreateMap<PersitentX, BusinessObjectX>();
                foreach (PropertyInfo prop in t.GetProperties())
                {
                    bool isPrimitive = IsPrimitive(prop.PropertyType);
                    bool isEnum = prop.PropertyType.IsEnum;
                    bool isList = IsList(prop);
                    if (!isPrimitive || isEnum && prop.CanRead && prop.CanWrite || isList)
                    {
                        map.ForMember(prop.Name, opt => opt.Ignore());
                    }
                }
                BusinessObjectX destination = (BusinessObjectX)Activator.CreateInstance<BusinessObjectX>();
                var customerViewItem = AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Transform BusinessObjects to Persistent
        /// <summary>
        /// Metodo que mapea dos objetos de negoci
        /// </summary>
        /// <param name="oObject"></param>
        /// <returns></returns>
        public virtual BusinessObject MapperBO2BO(BusinessObject oObject)
        {
            try
            {
                Type t = typeof(Persistent);
                var map = AutoMapper.Mapper.CreateMap<BusinessObject, BusinessObject>();
                foreach (PropertyInfo prop in t.GetProperties())
                {
                    bool isPrimitive = IsPrimitive(prop.PropertyType);
                    bool isEnum = prop.PropertyType.IsEnum;
                    bool isList = IsList(prop);
                    if (!isPrimitive || isEnum && prop.CanRead && prop.CanWrite || isList)
                    {
                        map.ForMember(prop.Name, opt => opt.Ignore());
                    }
                }
                BusinessObject destination = (BusinessObject)Activator.CreateInstance(typeof(BusinessObject));
                AdditionalSettings(map, oObject);
                var customerViewItem =
                   AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion
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
