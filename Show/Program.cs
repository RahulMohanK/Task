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
        public Type Itype;
        public int chClass,chMethod;
        public bool parseSuccess;


        public void inputchClass(int index)
        { 
            // int temp;
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out chClass);
               
                if (!parseSuccess || chClass>index || chClass<0 )
                {
                    Console.WriteLine("Enter valid option:");
                }
            }
            while (parseSuccess != true || chClass>index || chClass<0);
        }
        public void inputchMethod( int index)
        {
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out chMethod);
                if (!parseSuccess|| chMethod>index || chMethod<0)
                {
                    Console.WriteLine("Enter valid option:");
                }
            }
            while (parseSuccess != true || chMethod>index || chMethod<0);
        }
         public void Print()
        {
            int i = 0, j = 0;
            //  conClass, conMethod;
            var assembly = Assembly.Load("OperationLibrary");
            Type[] types = assembly.GetTypes();

            Dictionary<int, Type> dict = new Dictionary<int, Type>();
            Dictionary<int, string> dict2 = new Dictionary<int, string>();
            foreach (var type in types)
            {

                var typeinfo = type.GetTypeInfo();
                //Console.WriteLine("type" + typeinfo.FullName);
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

            while(true)
            {
                Console.Clear();
                Console.WriteLine("==========Main Menu==========\nPress 0 To Exit Application");
                foreach (KeyValuePair<int, Type> item in dict)
                {
                    Console.WriteLine("{0}. {1}", item.Key, (string)item.Value.FullName.Remove(0, 17));
                }
                Console.WriteLine("Enter option :");
                //int.TryParse(Console.ReadLine(), out chClass);
                inputchClass(i);
                if (chClass == 0)
                { break; }
                else
                {
                    while(true)
                    {
                        //Console.Clear();
                        Console.WriteLine("\n" + dict[chClass].FullName.Remove(0, 17) + "\n");
                        foreach (KeyValuePair<int, string> item in dict2)
                        {
                            Console.WriteLine("{0}. {1}", item.Key, item.Value);
                        }
                        Console.WriteLine("Enter Operation option (0 to Exit):");
                        inputchMethod(j);
                        //int.TryParse(Console.ReadLine(), out chMethod);
                        if (chMethod == 0)
                        { break; }
                        object obj = Activator.CreateInstance(dict[chClass]);
                        Console.WriteLine("\n"+dict2[chMethod]);
                        MethodInfo mi = dict[chClass].GetMethod(dict2[chMethod]);
                        mi.Invoke(obj, null);
                        // Console.WriteLine("Do you want to return to main Menu(yes-1/No-0):");
                        // int.TryParse(Console.ReadLine(), out conMethod);
                    }
                   
                    // Console.WriteLine("Do you want to Exit Application (yes-1/No-0):");
                    // int.TryParse(Console.ReadLine(), out conClass);
                }
            }
            // while (conClass != 1);


        }
        static void Main(string[] args)
        {       
            Program pgm = new Program();
            pgm.Print();
        }
    }
}
