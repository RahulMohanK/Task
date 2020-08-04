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
        public void AddToFile<T>(object obj)
        {

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                var rootNode = doc.GetElementsByTagName("Staff")[0];
                var nav = rootNode.CreateNavigator();
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

                using (var writer = nav.AppendChild())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    writer.WriteWhitespace("");
                    serializer.Serialize(writer, obj, emptyNamepsaces);
                    writer.Close();
                }
                doc.Save(path);

            }
            catch (Exception e)
            {
                Console.WriteLine("Xml add error" + e);
            }
        }
        public void RetrieveAllFromFile<T>()
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            XDocument xdoc;
            xdoc = XDocument.Load(path);
            xdoc.Save(path);
            IEnumerable<XElement> accounts = xdoc.Root.Descendants(typevalue);

            if (accounts.ToList().Count != 0)
            {
                foreach (XElement el in accounts)
                {

                    Console.WriteLine("Id :" + el.Attribute("Id").Value + "\n" + el);
                }
            }
            else
            {
                Console.WriteLine("\nList is Empty");
            }
        }
        public void DeleteFromFile<T>(int id)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            Console.WriteLine("id :{0}", id);

            XDocument xDocument;
            xDocument = XDocument.Load(path);
            int i = 0;
            bool flag = false;
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(typevalue);
            foreach (XElement el in accounts)
            {
                ++i;
                var check = el.Attribute("Id").Value;
                if (Convert.ToInt32(check) == id)
                {


                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Deleted :\n" + accounts.ElementAt(i - 1));
                accounts.ElementAt(i - 1).Remove();
                xDocument.Save(path);
            }
            else
            {
                Console.WriteLine("\nStaff Not Found!!");
            }

        }
        public object GetObj<T>(int id, object obj)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];

            int i = 0;
            bool flag = false;
            T t = (T)obj;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(typevalue);

            foreach (XElement el in accounts)
            {
                ++i;
                var check = el.Attribute("Id").Value;
                if (Convert.ToInt32(check) == id)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                var item = accounts.ElementAt(i - 1);
                using (TextReader reader = new StringReader(item.ToString()))
                {
                    t = (T)serializer.Deserialize(reader);
                }
            }

            return t;

        }
        public void UpdateFile<T>(int id, object obj)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            int i = 0;
            bool flag = false;

            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(typevalue);

            foreach (XElement el in accounts)
            {
                ++i;
                var check = el.Attribute("Id").Value;
                if (Convert.ToInt32(check) == id)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                accounts.ElementAt(i - 1).Remove();
                xDocument.Save(path);
                AddToFile<T>(obj);
            }
            else
            {
                Console.WriteLine("Staff Not Found");
            }

        }
        public void RetrieveFromFile<T>(string name)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            int iterator = 0;
            bool flag = false;
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> accounts = xDocument.Root.Descendants(typevalue);
            var node = from val in xDocument.Descendants(typevalue)
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