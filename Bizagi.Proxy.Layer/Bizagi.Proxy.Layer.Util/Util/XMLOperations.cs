using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Bizagi.Proxy.Layer.Util
{
    public static class XMLOperations
    {

        public static string XSLTransformation(string xsl, XmlDocument XMLInput)
        {
            string XMLOutput = "";

            XmlDocument xslt = new XmlDocument();
            xslt.LoadXml(xsl);
            XslCompiledTransform transformer = new XslCompiledTransform();
            transformer.Load(xslt);
            StringWriter writer = new StringWriter();
            transformer.Transform(XMLInput, null, writer);
            XMLOutput = writer.ToString();

            return XMLOutput;

        }


    }
}
