using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OperationLibrary
{

    public class StaffOperation
    {
        public string name, subject, email, dob, phone, designation, department;
        public bool parseSuccess;
        public int id;
        public bool valid;
        public void inputId()
        {
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out id);
                if (!parseSuccess)
                {
                    Console.WriteLine("Enter Valid Id:");
                }
            }
            while (parseSuccess != true);
        }
        public void EnterValues()
        {
            Console.WriteLine("Enter Teaching Details :");
            Console.WriteLine("Enter Id:");
            inputId();
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            Console.WriteLine("Enter Phone No (+ Country Code - Phone No):");
            phone = Console.ReadLine();

            Console.WriteLine("Enter date of birth (DD/MM/YYYY):");
            dob = Console.ReadLine();

            Console.WriteLine("Enter Email :");
            email = Console.ReadLine();

        }
        public void validation(object obj)
        {
            ValidationContext context = new ValidationContext(obj, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            valid = Validator.TryValidateObject(obj, context, validationResults, true);
            if (!valid)
            {
                foreach (ValidationResult validation in validationResults)
                {
                    Console.WriteLine(validation.ErrorMessage);
                }
            }
        }
        public void Print()
        {
            int chClass, chMethod, i = 0, j = 0, conClass, conMethod;
            var assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            Dictionary<int, Type> dict = new Dictionary<int, Type>();
            Dictionary<int, string> dict2 = new Dictionary<int, string>();
            foreach (var type in types)
            {

                var typeinfo = type.GetTypeInfo();
                dict.Add(++i, type);
            }
            var mis = dict[5].GetMethods();
            foreach (var type1 in mis)
            {
                dict2.Add(++j, type1.Name);
            }

            do
            {
                Console.Clear();
                foreach (KeyValuePair<int, Type> item in dict)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                }
                Console.WriteLine("Enter  option :");
                int.TryParse(Console.ReadLine(), out chClass);

                do
                {
                    Console.Clear();
                    Console.WriteLine("\n" + dict[chClass] + "\n");
                    foreach (KeyValuePair<int, string> item in dict2)
                    {
                        Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                    }
                    Console.WriteLine("Enter method option (6 to Exit):");
                    int.TryParse(Console.ReadLine(), out chMethod);
                    if (chMethod == 6)
                    { break; }
                    object obj = Activator.CreateInstance(dict[chClass]);
                    Console.WriteLine(dict2[chMethod]);
                    MethodInfo mi = dict[chClass].GetMethod(dict2[chMethod]);
                    mi.Invoke(obj, null);
                    Console.WriteLine("Do you want to return to main Menu(yes-1/No-0):");
                    int.TryParse(Console.ReadLine(), out conMethod);
                }
                while (conMethod != 1);
                Console.WriteLine("Do you want to Exit Application (yes-1/No-0):");
                int.TryParse(Console.ReadLine(), out conClass);
            }
            while (conClass != 1);


        }
    }

}