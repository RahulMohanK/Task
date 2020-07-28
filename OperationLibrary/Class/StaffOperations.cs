using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using StaffLibrary;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
namespace OperationLibrary
{

    public class StaffOperation
    {
        // public string name, subject, date, email, phone, designation, department;
        //public DateTime dob;
        //public bool parseSuccess;
        // public int id;
        //public bool valid;
        //public static string[] Options;
        //public int Select, Count = 0;

        public static string[] configList(string select)
        {
            string a = ConfigurationManager.AppSettings[select];
            string[] list = a.Split('|');
            return list;
        }
        public static int inputOption()
        {
            bool parseSuccess = false;
            int id;
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out id);
                if (!parseSuccess)
                {
                    Console.WriteLine("Enter valid option:");
                }
            }
            while (parseSuccess != true);
            return id;
        }
        public static string inputDob()
        {
            string date = "";
            bool parseSuccess = false;
            DateTime dob = DateTime.Now;

            do
            {
                date = Console.ReadLine();
                if (!String.IsNullOrEmpty(date))
                {
                    parseSuccess = DateTime.TryParse(date, out dob);
                    if (!parseSuccess)
                    {
                        Console.WriteLine("Enter Valid Date:");
                    }
                }
                else
                {
                    break;
                }

            }
            while (parseSuccess != true);
            if (String.IsNullOrEmpty(date))
            {
                return null;
            }
            else
            {

                return dob.ToString();
            }
        }
        public static string inputName()
        {
            string name = "";
            bool parseSuccess = false;
            do
            {
                string pattern = @"^[a-zA-Z. ]+$";
                name = Console.ReadLine();
                parseSuccess = Regex.IsMatch(name, pattern);
                if (!parseSuccess)
                {
                    Console.WriteLine("Enter Valid Name");
                }
            }
            while (parseSuccess != true);
            return name;
        }

        public static string[] EnterValues()
        {
            String[] fields = new String[4];
            string name = "", phone = "", email = "", dob = "";
            Console.WriteLine("=====Enter Details=====");
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();
            fields[0] = name;

            Console.WriteLine("Enter Phone No (+ Country Code - Phone No):");
            phone = Console.ReadLine();
            fields[1] = phone;

            Console.WriteLine("Enter date of birth (DD/MM/YYYY):");
            dob = inputDob();
            fields[2] = dob;


            Console.WriteLine("Enter Email :");
            email = Console.ReadLine();
            fields[3] = email;

            return fields;

        }
        public static bool validation(object obj)
        {
            bool valid = false;
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
            return valid;
        }

    }

}