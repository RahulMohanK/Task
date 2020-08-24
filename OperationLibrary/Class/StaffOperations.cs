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
        // public void AddStaff()
        // {

        // }
        // public void RetrieveAllStaff() { }
        // public void RetrieveSingleStaff() { }
        // public void EditStaff() { }
        // public void DeleteStaff() { }


        protected static string[] ConfigList(string select)
        {
            string a = ConfigurationManager.AppSettings[select];
            string[] list = a.Split('|');
            return list;
        }
        protected static int InputOption()
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
        protected static string InputDob()
        {
            string date = "";
            bool parseSuccess = false;
            DateTime dob = DateTime.Now;
            string retVal = "";

            do
            {
                date = Console.ReadLine();
                if (!String.IsNullOrEmpty(date))
                {
                    parseSuccess = DateTime.TryParse(date, out dob);
                    retVal = dob.ToString();
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
            return retVal;
        }
        protected static string InputName()
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

        protected static object[] EnterValues()
        {
            object[] fields = new object[5];
            string name = "", phone = "", email = "", dob = "";
            string id;
            // DateTime dob = DateTime.Now;
            Console.WriteLine("=====Enter Details=====");
            Console.WriteLine("Enter EmpId :");
            id = Console.ReadLine();
            fields[4] = id;

            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();
            fields[0] = name;

            Console.WriteLine("Enter Phone No (+ Country Code - Phone No):");
            phone = Console.ReadLine();
            fields[1] = phone;

            Console.WriteLine("Enter date of birth (DD/MM/YYYY):");
            dob = InputDob();
            fields[2] = dob;


            Console.WriteLine("Enter Email :");
            email = Console.ReadLine();
            fields[3] = email;


            return fields;

        }
        protected static bool Validation(object obj)
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