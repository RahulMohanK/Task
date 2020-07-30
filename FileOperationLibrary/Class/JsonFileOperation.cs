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
        string path = @"C:\Users\Workstation\Desktop\Staff\staff.json";
        public void AddToFile(object obj, string staffname)
        {
            try
            {

                var json = File.ReadAllText(path);
                var jsonObj = JObject.Parse(json);
                var stafflist = jsonObj.GetValue(staffname) as JArray;

                var item = JsonConvert.SerializeObject(obj);
                stafflist.Add(item);

                jsonObj[staffname] = stafflist;
                string newJsonResult = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("File addition error" + e);
            }
            string jsonN = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(jsonN);
        }


        public void RetrieveAllFromFile(string staffname)
        {

            int id = 0;
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                var stafflist = jobj.GetValue(staffname) as JArray;

                if (stafflist.HasValues)
                {
                    foreach (var item in stafflist)
                    {
                        Console.WriteLine("Id :" + (++id) + " " + item);
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
        public void DeleteFromFile(int id, string staffname)
        {
            //int i = 0;
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                var stafflist = jobj.GetValue(staffname) as JArray;
                if (id <= stafflist.Count)
                {
                    Console.WriteLine(stafflist[id - 1] + "\n Deleted Succesfully");
                    stafflist.RemoveAt(id - 1);

                }
                else
                {
                    Console.WriteLine("\nStaff Not Found !!");
                }

                jobj[staffname] = stafflist;

                string newJsonResult = JsonConvert.SerializeObject(jobj, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Deletion Error :" + e);
            }
        }

        public void RetrieveFromFile(string name, string staffname)
        {
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                //Console.WriteLine(jobj[staffname]);
                var definition = new { Name = "" };
                if (jobj[staffname].HasValues)
                {
                    foreach (var item in jobj[staffname])
                    {
                        var it = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);

                        if (name.Equals(it.Name))
                        {
                            Console.WriteLine(item);
                            //Console.WriteLine(it.Name);
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

        public object GetObj<T>(int id, string staffname, object obj)
        {
            var json = File.ReadAllText(path);
            T t = (T)obj;
            try
            {
                var jobj = JObject.Parse(json);
                JArray stafflist = jobj.GetValue(staffname) as JArray;
                var definition = new { Name = "", Designation = "" };
                int iterator = 0;
                foreach (var item in stafflist)
                {
                    ++iterator;
                    if (id == iterator)
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
        public void UpdateFile(int id, string staffname, object obj)
        {
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                JArray stafflist = jobj.GetValue(staffname) as JArray;
                var definition = new { Name = "", Designation = "" };
                stafflist.RemoveAt(id - 1);
                var item = JsonConvert.SerializeObject(obj);
                stafflist.Add(item);
                jobj[staffname] = stafflist;
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