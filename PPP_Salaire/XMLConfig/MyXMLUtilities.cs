using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace PPP_Salaire.XMLConfig
{
    public class MyXMLUtilities
    {

        public static List<string> GetAttributes(string entity)
        {
            List<string> list = new List<string>();
            var serializer = new XmlSerializer(typeof(XmlNode));
            string filepath = HttpContext.Current.Server.MapPath("~") + "/XMLConfig/" + entity + ".xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            XmlNode root = null;
            using (var reader = XmlReader.Create(filepath, settings))
            {
                root = (XmlNode)serializer.Deserialize(reader);
            }
            foreach (XmlNode item in root.ChildNodes)
            {
                foreach (XmlNode subitem in item.ChildNodes)
                {
                    list.Add(subitem.InnerText);
                }
            }
            return list;
        }

        public static List<string> GetAttributes(string entity, string attributesType)
        {
            List<string> list = new List<string>();
            var serializer = new XmlSerializer(typeof(XmlNode));
            string filepath = HttpContext.Current.Server.MapPath("~") + "/XMLConfig/" + entity + ".xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            XmlNode root = null;
            using (var reader = XmlReader.Create(filepath, settings))
            {
                root = (XmlNode)serializer.Deserialize(reader);
            }
            foreach (XmlNode item in root.ChildNodes)
            {
                if (item.Name == attributesType)
                {
                    foreach (XmlNode ByDefaultitem in item.ChildNodes)
                    {
                        list.Add(ByDefaultitem.InnerText);
                    }
                }
            }
            return list;
        }

        public static void UpdateChosenAttributes(string entity, IList<string> list)
        {
            var serializer = new XmlSerializer(typeof(XmlNode));
            string filepath = HttpContext.Current.Server.MapPath("~") + "/XMLConfig/" + entity + ".xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            XmlNode root = null;
            using (var reader = XmlReader.Create(filepath, settings))
            {
                root = (XmlNode)serializer.Deserialize(reader);
            }
            foreach (XmlNode item in root.ChildNodes)
            {
                if (item.Name == "CheckedAttributes")
                {
                    item.RemoveAll();
                    foreach (var newitem in list)
                    {
                        XmlNode xn = new XmlDocument()
                            .CreateNode(XmlNodeType.Element, "CheckedAttribute", null);
                        xn.InnerText = newitem;
                        xn = item.OwnerDocument.ImportNode(xn, true);
                        item.AppendChild(xn);
                    }
                }
            }
            XmlWriterSettings wsettings = new XmlWriterSettings();
            wsettings.Indent = true;
            using (var writer = XmlWriter.Create(filepath, wsettings))
            {
                serializer.Serialize(writer, root);
            }
        }

        public static IDictionary<int, string>[] GetRegle()
        {
            IDictionary<int, string> dictSal = new Dictionary<int, string>();
            IDictionary<int, string> dictRemun = new Dictionary<int, string>();
            IDictionary<int, string> dictCotis = new Dictionary<int, string>();
            IDictionary<int, string> dictArithm = new Dictionary<int, string>();

            var serializer = new XmlSerializer(typeof(XmlNode));
            string filepath = HttpContext.Current.Server.MapPath("~") + "/XMLConfig/regle.xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            XmlNode root = null;
            using (var reader = XmlReader.Create(filepath, settings))
            {
                root = (XmlNode)serializer.Deserialize(reader);
            }
            int i = 0;
            foreach (XmlNode item in root.ChildNodes)
            {
                switch (item.Name)
                {
                    case"Salaire":
                        dictSal.Add(i, item.InnerText);
                        i++;
                        break;
                    case"Remuneration":
                        dictRemun.Add(i, item.InnerText);
                        i++;
                        break;
                    case"Cotisation":
                        dictCotis.Add(i, item.InnerText);
                        i++;
                        break;
                    case"Arithmetique":
                        dictArithm.Add(i, item.InnerText);
                        i++;
                        break;
                }
            }

            return new IDictionary<int, string>[] { dictSal, dictRemun, dictCotis, dictArithm };
        }

        public static void SauvgarderRegle(IDictionary<int, string> dictSal
            , IDictionary<int, string> dictRemun, IDictionary<int, string> dictCotis
            , IDictionary<int, string> dictArithm, int count)
        {
            XmlNode root = new XmlDocument().CreateNode(XmlNodeType.Element, "regle", null);
            for (int i = 0; i < count; i++)
            {
                XmlNode xn = null;
                bool trouve = false;
                int j = 0;
                while ((!trouve) && (j < dictSal.Count))
                {
                    if (dictSal.ElementAt(j).Key == i)
                    {
                        xn = new XmlDocument().CreateNode(XmlNodeType.Element, "Salaire", null);
                        xn.InnerText = dictSal.ElementAt(j).Value;
                        trouve = true;
                    }
                    j++;
                }
                j = 0;
                while ((!trouve) && (j < dictRemun.Count))
                {
                    if (dictRemun.ElementAt(j).Key == i)
                    {
                        xn = new XmlDocument().CreateNode(XmlNodeType.Element, "Remuneration", null);
                        xn.InnerText = dictRemun.ElementAt(j).Value;
                        trouve = true;
                    }
                    j++;
                }
                j = 0;
                while ((!trouve) && (j < dictCotis.Count))
                {
                    if (dictCotis.ElementAt(j).Key == i)
                    {
                        xn = new XmlDocument().CreateNode(XmlNodeType.Element, "Cotisation", null);
                        xn.InnerText = dictCotis.ElementAt(j).Value;
                        trouve = true;
                    }
                    j++;
                }
                j = 0;
                while ((!trouve) && (j < dictArithm.Count))
                {
                    if (dictArithm.ElementAt(j).Key == i)
                    {
                        xn = new XmlDocument().CreateNode(XmlNodeType.Element, "Arithmetique", null);
                        xn.InnerText = dictArithm.ElementAt(j).Value;
                        trouve = true;
                    }
                    j++;
                }
                xn.InnerText.Replace(" ", "_");
                xn = root.OwnerDocument.ImportNode(xn, true);
                root.AppendChild(xn);
            }
            var serializer = new XmlSerializer(typeof(XmlNode));
            string filepath = HttpContext.Current.Server.MapPath("~") + "/XMLConfig/regle.xml";
            XmlWriterSettings wsettings = new XmlWriterSettings();
            wsettings.Indent = true;
            using (var writer = XmlWriter.Create(filepath, wsettings))
            {
                serializer.Serialize(writer, root);
            }
        }
    }
}