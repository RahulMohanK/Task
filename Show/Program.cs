using System;
using StaffLibrary;
using OperationLibrary;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Configuration;

namespace Show
{

    class Program
    {
        private static string GetItemName(System.Type type)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);
            var attrname = attrs[0] as DisplayNameAttribute;
            return attrname.DisplayName;

        }
        private static int InputchClass(int index, int chClass)
        {
            bool parseSuccess;
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out chClass);

                if (!parseSuccess || chClass > index || chClass < 0)
                {
                    Console.WriteLine("Enter valid option:");
                }
            }
            while (parseSuccess != true || chClass > index || chClass < 0);
            return chClass;
        }
        private static int InputchMethod(int index, int chMethod)
        {
            bool parseSuccess;
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out chMethod);
                if (!parseSuccess || chMethod > index || chMethod < 0)
                {
                    Console.WriteLine("Enter valid option:");
                }
            }
            while (parseSuccess != true || chMethod > index || chMethod < 0);
            return chMethod;
        }

        static void Main(string[] args)
        {
            int i = 0, j = 0;
            Type Itype = null;
            int chClass = -1, chMethod = -1;
            string attrname;
            var assembly = Assembly.Load("OperationLibrary");
            Type[] types = assembly.GetTypes();

            Dictionary<int, Type> dict = new Dictionary<int, Type>();
            Dictionary<int, MethodInfo> dict2 = new Dictionary<int, MethodInfo>();
            foreach (var type in types)
            {

                var typeinfo = type.GetTypeInfo();

                if (typeinfo.FullName != "OperationLibrary.StaffOperation" && typeinfo.FullName != "OperationLibrary.IStaffOperation")
                {
                    dict.Add(++i, type);
                }
                else if (typeinfo.FullName == "OperationLibrary.IStaffOperation")
                {
                    Itype = type;
                }


            }
            var mis = Itype.GetMethods();
            foreach (var type1 in mis)
            {
                dict2.Add(++j, type1);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========Main Menu==========\nPress 0 To Exit Application");
                foreach (KeyValuePair<int, Type> item in dict)
                {
                    attrname = GetItemName(item.Value);
                    Console.WriteLine("{0}. {1}", item.Key, attrname);
                }
                Console.WriteLine("Enter option :");

                chClass = InputchClass(i, chClass);
                if (chClass == 0)
                { break; }
                else
                {
                    while (true)
                    {
                        attrname = GetItemName(dict[chClass]);
                        Console.WriteLine("\n" + attrname + "\n");
                        foreach (KeyValuePair<int, MethodInfo> item in dict2)
                        {
                            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(item.Value);
                            var dname = attrs[0] as DisplayNameAttribute;

                            Console.WriteLine("{0}. {1}", item.Key, dname.DisplayName);
                        }
                        Console.WriteLine("Enter Operation option (0 to Exit):");
                        chMethod = InputchMethod(j, chMethod);

                        if (chMethod == 0)
                        { break; }
                        object obj = Activator.CreateInstance(dict[chClass]);
                        System.Attribute[] attr = System.Attribute.GetCustomAttributes(dict2[chMethod]);
                        var dnam = attr[0] as DisplayNameAttribute;
                        Console.WriteLine("\n-----" + dnam.DisplayName + "-----\n");
                        MethodInfo mi = dict[chClass].GetMethod(dict2[chMethod].Name);
                        mi.Invoke(obj, null);

                    }


                }
            }

        }
    }
}
