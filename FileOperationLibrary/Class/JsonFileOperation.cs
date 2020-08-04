using Newtonsoft.Json;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
namespace FileOperationLibrary
{
    public class JsonFileOperation : IFileOperation
    {
        string path = @"staff.json";
        public void AddToFile<T>(object obj)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            try
            {

                var json = File.ReadAllText(path);
                var jsonObj = JObject.Parse(json);
                var stafflist = jsonObj.GetValue(typevalue) as JArray;

                var item = JsonConvert.SerializeObject(obj);
                stafflist.Add(item);

                jsonObj[typevalue] = stafflist;
                string newJsonResult = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("File addition error" + e);
            }
            string jsonN = JsonConvert.SerializeObject(obj, Formatting.Indented);
        }


        public void RetrieveAllFromFile<T>()
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];

            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                var stafflist = jobj.GetValue(typevalue) as JArray;
                var definition = new { Id = "" };
                if (stafflist.HasValues)
                {
                    foreach (var item in stafflist)
                    {
                        var content = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);
                        Console.WriteLine("Id :" + content.Id + " " + item);
                    }
                }
                else
                {
                    Console.WriteLine("List is Empty");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Retieval Error :" + e);
            }
        }
        public void DeleteFromFile<T>(int id)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            int i = 0;
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                var stafflist = jobj.GetValue(typevalue) as JArray;
                var definition = new { Id = "" };
                if (id <= stafflist.Count)
                {
                    foreach (var item in stafflist)
                    {
                        ++i;
                        var content = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);
                        if (Convert.ToInt32(content.Id) == id)
                        {
                            break;
                        }
                    }
                    Console.WriteLine(stafflist[i - 1] + "\n Deleted Succesfully");
                    stafflist.RemoveAt(i - 1);

                }
                else
                {
                    Console.WriteLine("\nStaff Not Found !!");
                }

                jobj[typevalue] = stafflist;

                string newJsonResult = JsonConvert.SerializeObject(jobj, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Deletion Error :" + e);
            }
        }

        public void RetrieveFromFile<T>(string name)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);

                var definition = new { Name = "" };
                if (jobj[typevalue].HasValues)
                {
                    foreach (var item in jobj[typevalue])
                    {
                        var it = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);

                        if (name.Equals(it.Name))
                        {
                            Console.WriteLine(item);

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Staff Not Found !!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Single Staff Error :", e);
            }
        }

        public object GetObj<T>(int id, object obj)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];

            var json = File.ReadAllText(path);
            T t = (T)obj;
            try
            {
                var jobj = JObject.Parse(json);
                JArray stafflist = jobj.GetValue(typevalue) as JArray;
                var definition = new { Id = "" };

                foreach (var item in stafflist)
                {

                    var content = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);
                    if (id == Convert.ToInt32(content.Id))
                    {
                        t = JsonConvert.DeserializeObject<T>(item.ToString());
                        break;

                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Get Value: " + e);
            }
            return t;
        }
        public void UpdateFile<T>(int id, object obj)
        {
            string[] type = typeof(T).ToString().Split('.');
            var typevalue = type[1];
            int i = 0;
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                JArray stafflist = jobj.GetValue(typevalue) as JArray;
                var definition = new { Id = "" };
                foreach (var it in stafflist)
                {
                    ++i;
                    var content = JsonConvert.DeserializeAnonymousType(it.ToString(), definition);
                    if (id == Convert.ToInt32(content.Id))
                    {

                        break;

                    }
                }
                stafflist.RemoveAt(i - 1);


                var item = JsonConvert.SerializeObject(obj);
                stafflist.Add(item);
                jobj[typevalue] = stafflist;
                string output = JsonConvert.SerializeObject(jobj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);

            }
            catch (Exception e)
            {
                Console.WriteLine("Updation Error: " + e);
            }
        }

    }
}