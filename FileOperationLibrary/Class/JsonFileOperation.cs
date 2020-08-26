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
        public void AddToFile<T>(T obj)
        {
            string staffType = typeof(T).ToString().Split('.')[1];

            try
            {

                var json = File.ReadAllText(path);
                var jsonObj = JObject.Parse(json);
                var stafflist = jsonObj.GetValue(staffType) as JArray;

                var item = JsonConvert.SerializeObject(obj);
                stafflist.Add(item);

                jsonObj[staffType] = stafflist;
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
            string staffType = typeof(T).ToString().Split('.')[1];


            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                var stafflist = jobj.GetValue(staffType) as JArray;
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
        public void DeleteFromFile<T>(string EmpId)
        {
            string staffType = typeof(T).ToString().Split('.')[1];
            int flag = 0;
            int i = 0;
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                var stafflist = jobj.GetValue(staffType) as JArray;
                var definition = new { Id = "" };

                foreach (var item in stafflist)
                {
                    ++i;
                    var content = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);
                    if (content.Id == EmpId)
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 1)
                {
                    Console.WriteLine(stafflist[i - 1] + "\n Deleted Succesfully");
                    stafflist.RemoveAt(i - 1);
                }

                else
                {
                    Console.WriteLine("\nStaff Not Found !!");
                }

                jobj[staffType] = stafflist;

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
            string staffType = typeof(T).ToString().Split('.')[1];

            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);

                var definition = new { Name = "" };
                if (jobj[staffType].HasValues)
                {
                    foreach (var item in jobj[staffType])
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

        public object GetObj<T>(string EmpId, T obj)
        {
            string staffType = typeof(T).ToString().Split('.')[1];


            var json = File.ReadAllText(path);
            T t = (T)obj;
            try
            {
                var jobj = JObject.Parse(json);
                JArray stafflist = jobj.GetValue(staffType) as JArray;
                var definition = new { Id = "" };

                foreach (var item in stafflist)
                {

                    var content = JsonConvert.DeserializeAnonymousType(item.ToString(), definition);
                    if (EmpId == content.Id)
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
        public void UpdateFile<T>(string EmpId, T obj)
        {
            string staffType = typeof(T).ToString().Split('.')[1];

            int i = 0;
            var json = File.ReadAllText(path);
            try
            {
                var jobj = JObject.Parse(json);
                JArray stafflist = jobj.GetValue(staffType) as JArray;
                var definition = new { Id = "" };
                foreach (var it in stafflist)
                {
                    ++i;
                    var content = JsonConvert.DeserializeAnonymousType(it.ToString(), definition);
                    if (EmpId == content.Id)
                    {

                        break;

                    }
                }
                stafflist.RemoveAt(i - 1);


                var item = JsonConvert.SerializeObject(obj);
                stafflist.Add(item);
                jobj[staffType] = stafflist;
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