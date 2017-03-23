using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Bizagi.XLS.Manager
{
    public class ExcelFactory
    {
        public string aConnectionString;
        private OleDbConnection aConnection;
        private string aPathFile;


        public ExcelFactory(string pathFile)
        {
            string text = Path.GetExtension(pathFile).ToUpper();

            if (text == ".XLS")
            {
                aConnectionString = "Data Source=" + pathFile + ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=YES;\"";
            }
            else
            {
                if (!(text == ".XLSM") && !(text == ".XLSX"))
                {
                    throw new Exception("Format " + text + " is not supported.");
                }
                aConnectionString = "Data Source=" + pathFile + ";Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=\"Excel 12.0 Macro;HDR=YES\"";
            }

            this.PathFile = pathFile;

        }


        private string PathFile
        {
            get
            {
                return this.aPathFile;
            }
            set
            {
                this.aPathFile = value;
            }
        }

        private string ConnectionString
        {
            get
            {
                return this.aConnectionString;
            }
            set
            {
                this.aConnectionString = value;
            }
        }


        public DataSet ReadExcel(string query)
        {
            DataSet result;
            try
            {
                OleDbConnection aConnection = this.Connection;

                OleDbCommand selectCommand = new OleDbCommand(query, this.Connection);
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet);
                result = dataSet;
            }
            catch (Exception innerException)
            {
                throw new Exception("Error reading query: " + query, innerException);
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        public string FromExcelToXMLString(string sWorksheetName, string sQuery)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlNode = xmlDocument.CreateElement(sWorksheetName.ToUpper());
            xmlDocument.AppendChild(xmlNode);
            try
            {
                DataSet dataSet = this.ReadExcel(sQuery);
                Console.WriteLine("Excel File Loaded");
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    XmlNode xmlNode2 = xmlDocument.CreateElement("ROW");
                    xmlNode.AppendChild(xmlNode2);
                    for (int j = 0; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        XmlElement xmlElement = xmlDocument.CreateElement(dataSet.Tables[0].Columns[j].ColumnName);
                        XmlCDataSection newChild = xmlDocument.CreateCDataSection(dataSet.Tables[0].Rows[i].ItemArray[j].ToString().Trim());
                        xmlElement.AppendChild(newChild);
                        xmlNode2.AppendChild(xmlElement);
                    }
                }

            }
            catch (Exception ex)
            {
                XmlNode xmlNode3 = xmlDocument.CreateElement("ERROR");
                xmlNode.AppendChild(xmlNode3);
                XmlNode xmlNode4 = xmlDocument.CreateElement("DESCRIPTION");
                xmlNode3.AppendChild(xmlNode4);
                xmlNode4.InnerText = ex.ToString();
            }
            finally
            {
                this.CloseConnection();
            }
            return xmlDocument.InnerXml;
        }

        public XmlDocument FromExcelToXML(string sWorksheetName, string sQuery)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlNode = xmlDocument.CreateElement(sWorksheetName.ToUpper());
            xmlDocument.AppendChild(xmlNode);
            try
            {
                DataSet dataSet = this.ReadExcel(sQuery);
                Console.WriteLine("Excel File Loaded");
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    XmlNode xmlNode2 = xmlDocument.CreateElement("ROW");
                    xmlNode.AppendChild(xmlNode2);
                    for (int j = 0; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        XmlElement xmlElement = xmlDocument.CreateElement(dataSet.Tables[0].Columns[j].ColumnName);
                        XmlCDataSection newChild = xmlDocument.CreateCDataSection(dataSet.Tables[0].Rows[i].ItemArray[j].ToString().Trim());
                        xmlElement.AppendChild(newChild);
                        xmlNode2.AppendChild(xmlElement);
                    }
                }

            }
            catch (Exception ex)
            {
                XmlNode xmlNode3 = xmlDocument.CreateElement("ERROR");
                xmlNode.AppendChild(xmlNode3);
                XmlNode xmlNode4 = xmlDocument.CreateElement("DESCRIPTION");
                xmlNode3.AppendChild(xmlNode4);
                xmlNode4.InnerText = ex.ToString();
            }
            finally
            {
                this.CloseConnection();
            }
            return xmlDocument;
        }

        private void CloseConnection()
        {
            try
            {
                if (this.aConnection != null)
                {
                    if (this.aConnection.State != ConnectionState.Closed)
                    {
                        this.aConnection.Close();
                    }
                    this.aConnection.Dispose();
                    this.aConnection = null;
                }
            }
            catch (Exception)
            {
            }
        }

        public OleDbConnection Connection
        {
            get
            {
                if (this.aConnection != null)
                {
                    if (this.aConnection.State == ConnectionState.Closed)
                    {
                        this.OpenConnection();
                    }
                }
                else
                {
                    this.aConnection = new OleDbConnection(this.aConnectionString);
                    this.OpenConnection();
                }
                return this.aConnection;
            }
            set
            {
                this.aConnection = value;
            }
        }


        private void OpenConnection()
        {
            try
            {
                if (!File.Exists(this.PathFile))
                {
                    throw new Exception("Excel file " + this.PathFile + " could not be found.");
                }
                this.aConnection = new OleDbConnection(this.aConnectionString);
                this.aConnection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error opening connection " + ex.Message, ex);
            }
        }
    }
}
