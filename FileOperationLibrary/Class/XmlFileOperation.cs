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
        public void AddToFile<T>(T obj)
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
            string staffType = typeof(T).ToString().Split('.')[1];
            XDocument xdoc;
            xdoc = XDocument.Load(path);
            xdoc.Save(path);
            IEnumerable<XElement> staffElements = xdoc.Root.Descendants(staffType);

            if (staffElements.ToList().Count != 0)
            {
                foreach (XElement el in staffElements)
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
            string staffType = typeof(T).ToString().Split('.')[1];

            Console.WriteLine("id :{0}", id);

            XDocument xDocument;
            xDocument = XDocument.Load(path);
            int i = 0;
            bool flag = false;
            IEnumerable<XElement> staffElements = xDocument.Root.Descendants(staffType);
            foreach (XElement el in staffElements)
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
                Console.WriteLine("Deleted :\n" + staffElements.ElementAt(i - 1));
                staffElements.ElementAt(i - 1).Remove();
                xDocument.Save(path);
            }
            else
            {
                Console.WriteLine("\nStaff Not Found!!");
            }

        }
        public object GetObj<T>(int id, T obj)
        {
            string staffType = typeof(T).ToString().Split('.')[1];


            int i = 0;
            bool flag = false;
            T t = (T)obj;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> staffElements = xDocument.Root.Descendants(staffType);

            foreach (XElement el in staffElements)
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
                var item = staffElements.ElementAt(i - 1);
                using (TextReader reader = new StringReader(item.ToString()))
                {
                    t = (T)serializer.Deserialize(reader);
                }
            }

            return t;

        }
        public void UpdateFile<T>(int id, T obj)
        {
            string staffType = typeof(T).ToString().Split('.')[1];

            int i = 0;
            bool flag = false;

            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> staffElements = xDocument.Root.Descendants(staffType);

            foreach (XElement el in staffElements)
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
                staffElements.ElementAt(i - 1).Remove();
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
            string staffType = typeof(T).ToString().Split('.')[1];
            int iterator = 0;
            bool flag = false;
            XDocument xDocument;
            xDocument = XDocument.Load(path);
            IEnumerable<XElement> staffElements = xDocument.Root.Descendants(staffType);
            var node = from val in xDocument.Descendants(staffType)
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
                    Console.WriteLine(staffElements.ElementAt(iterator - 1));
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