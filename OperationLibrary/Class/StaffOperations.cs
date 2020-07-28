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
        public string name, subject,date, email, phone, designation, department;
        public DateTime dob;
        public bool parseSuccess;
        public int id;
        public bool valid;
        public static string[] Options;
        public int Select, Count = 0;
        public void test(Staff staff)
        {


        }
       
        public string[] configList(string select)
        {
            string a = ConfigurationManager.AppSettings[select];
            string[] list = a.Split('|');
            return list;
        }
        public void inputOption()
        {
            do
            {
                parseSuccess = int.TryParse(Console.ReadLine(), out id);
                if (!parseSuccess)
                {
                    Console.WriteLine("Enter valid option:");
                }
            }
            while (parseSuccess != true);
        }
        public void inputDob()
        {
            do
            {
                parseSuccess = DateTime.TryParse(Console.ReadLine(), out dob);
                if (!parseSuccess)
                {
                    Console.WriteLine("Enter Valid Date:");
                }
            }
            while (parseSuccess != true) ;
        }
        public void inputName()
        {
            do
            {
                    string pattern =@"^[a-zA-Z. ]+$";
                    name = Console.ReadLine();
                    parseSuccess = Regex.IsMatch(name,pattern);
                if (!parseSuccess)
                {
                    Console.WriteLine("Enter Valid Name");
                }
            }
            while (parseSuccess != true) ;
        }
        
        public void EnterValues()
        {
            Console.WriteLine("Enter Details :\n");
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            Console.WriteLine("Enter Phone No (+ Country Code - Phone No):");
            phone = Console.ReadLine();

            Console.WriteLine("Enter date of birth (DD/MM/YYYY):");
            inputDob();

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

    }

}