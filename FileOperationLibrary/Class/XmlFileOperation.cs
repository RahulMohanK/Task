using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FileOperationLibrary
{
    public class XmlFileOperation : IFileOperation
    {
        string path = @"staff.xml";
        public void AddToFile<T>(object obj, string staffname)
        {
            try
            {

                string[] tagname = staffname.Split(' ');
                StringWriter xml = new StringWriter();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlWriterSettings writtersetting = new XmlWriterSettings();
                writtersetting.OmitXmlDeclaration = true;

                using (XmlWriter writer = XmlWriter.Create(xml, writtersetting))
                {
                    xmlSerializer.Serialize(writer, obj, ns);
                }
                XmlNode xnode = doc.CreateNode(XmlNodeType.Element, tagname[0], null);

                xnode.InnerXml = xml.ToString();
                doc.DocumentElement.AppendChild(xnode);

                doc.Save(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Xml add error" + e);
            }
        }
        public void RetrieveAllFromFile<T>(string staffname)
        {
            XDocument xdoc;
            xdoc = XDocument.Load(path);
            xdoc.Save(path);
            int iterator = 0;
            IEnumerable<XElement> accounts = xdoc.Root.Descendants(staffname.Replace(" ", ""));
            if (accounts.ToList().Count != 0)
            {
                foreach (XElement el in accounts)
                {
                    ++iterator;
                    Console.WriteLine(iterator + " :" + el);
                }
            }
            else
            {
                Console.WriteLine("\nList is Empty");
            }

            // var result = from q in xdoc.Descendants(staffname.Replace(" ", ""))
            //              select new
            //              {
            //                  Name = q.Element("Name").Value,
            //                  Phone = q.Element("Phone").Value,

            //              };
            // foreach (var item in result)
            // {
            //     Console.WriteLine("Name :{0}, Phone:{1}", item.Name, item.Phone);
            // }


        }
        public void DeleteFromFile(int id, string staffname)
        {

            string[] tagname = staffname.Split(' ');
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(tagname[0]);
            if (id <= accounts.ToList().Count && id > 0)
            {
                Console.WriteLine("Deleted :\n" + accounts.ElementAt(id - 1));
                accounts.ElementAt(id - 1).Remove();
                xDocument.Save(path);
            }
            else
            {
                Console.WriteLine("\nStaff Not Found!!");
            }

        }
        public object GetObj<T>(int id, string staffname, object obj)
        {
            T t = (T)obj;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(staffname.Replace(" ", ""));
            if (id <= accounts.ToList().Count && id > 0)
            {
                var item = accounts.ElementAt(id - 1);
                using (TextReader reader = new StringReader(item.ToString()))
                {
                    t = (T)serializer.Deserialize(reader);
                }

            }
            return t;

        }
        public void UpdateFile<T>(int id, string staffname, object obj)
        {

            string[] tagname = staffname.Split(' ');
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(tagname[0]);
            if (id <= accounts.ToList().Count && id > 0)
            {
                accounts.ElementAt(id - 1).Remove();
                xDocument.Save(path);
                AddToFile<T>(obj, staffname);
            }
            else
            {
                Console.WriteLine("Staff Not Found");
            }

        }
        public void RetrieveFromFile(string name, string staffname)
        {
            int iterator = 0;
            bool flag = false;
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(staffname.Replace(" ", ""));
            var node = from val in xDocument.Descendants(staffname.Replace(" ", ""))
                       select new
                       {
                           Name = val.Element("Name").Value
                       };

            foreach (var item in node)
            {
                ++iterator;
                if (item.Name == name)
                {

                    Console.WriteLine("Name:{0}", item.Name);
                    Console.WriteLine(accounts.ElementAt(iterator - 1));
                    flag = true;

                }
            }
            if (!flag)
            {
                Console.WriteLine("Staff Not Found!!");
            }


        }

    }
}