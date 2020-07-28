using System;
using StaffLibrary;
using OperationLibrary;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Show
{

    class Program
    {
        static int inputchClass(int index, int chClass)
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
        static int inputchMethod(int index, int chMethod)
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

            var assembly = Assembly.Load("OperationLibrary");
            Type[] types = assembly.GetTypes();

            Dictionary<int, Type> dict = new Dictionary<int, Type>();
            Dictionary<int, string> dict2 = new Dictionary<int, string>();
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
                dict2.Add(++j, type1.Name);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==========Main Menu==========\nPress 0 To Exit Application");
                foreach (KeyValuePair<int, Type> item in dict)
                {
                    Console.WriteLine("{0}. {1}", item.Key, (string)item.Value.FullName.Remove(0, 17));
                }
                Console.WriteLine("Enter option :");

                chClass = inputchClass(i, chClass);
                if (chClass == 0)
                { break; }
                else
                {
                    while (true)
                    {

                        Console.WriteLine("\n" + dict[chClass].FullName.Remove(0, 17) + "\n");
                        foreach (KeyValuePair<int, string> item in dict2)
                        {
                            Console.WriteLine("{0}. {1}", item.Key, item.Value);
                        }
                        Console.WriteLine("Enter Operation option (0 to Exit):");
                        chMethod = inputchMethod(j, chMethod);

                        if (chMethod == 0)
                        { break; }
                        object obj = Activator.CreateInstance(dict[chClass]);
                        Console.WriteLine("\n" + dict2[chMethod]);
                        MethodInfo mi = dict[chClass].GetMethod(dict2[chMethod]);
                        mi.Invoke(obj, null);

                    }


                }
            }
        }
    }
}
