using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel.DataAnnotations;
namespace OperationLibrary
{
     public class SupportStaffOperation : IStaffOperation
    {
        public string name ,subject,email,dob,phone,designation,department;

        public int id; 
        public bool parseSuccess;
        static List<SupportStaff> supportList = new List<SupportStaff>();

        public void inputId()
        {
            do{
            parseSuccess = int.TryParse(Console.ReadLine(),out id);
            if(!parseSuccess)
            {
                Console.WriteLine("Enter Valid Id:");
            }
            }
            while(parseSuccess!= true);
        }
        public  void EnterValues()
        {
             Console.WriteLine("Enter Support Details :");
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

            Console.WriteLine("Enter Department :");
            department = Console.ReadLine();
        }
        public void validation(SupportStaff support)
        {
            ValidationContext context = new ValidationContext(support,null,null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(support,context,validationResults,true);
            if(!valid)
            {
                foreach(ValidationResult validation in validationResults)
                {
                    Console.WriteLine(validation.ErrorMessage);
                }
            }
        }
         public  void AddStaff()
        {
           
            EnterValues();
            SupportStaff support= new SupportStaff();
            support.Id=Convert.ToInt32(id);
            support.Name=name;
            support.Phone=phone;
            support.Dob=dob;
            support.Email = email;
            support.Department=department;
           
             if(support!=null)
            {
            ValidationContext context = new ValidationContext(support,null,null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(support,context,validationResults,true);
            if(!valid)
            {
                foreach(ValidationResult validation in validationResults)
                {
                    Console.WriteLine(validation.ErrorMessage);
                }
            }else{
            supportList.Add(support);
            Console.WriteLine("\nValues added are :\n");
    
            Console.WriteLine("Id :"+support.Id+ " Name: "+support.Name+" "+"DOB: "+support.Dob+" "+"Phone :"+support.Phone+" "+"Email :"+support.Email+" Department: "+support.Department);
            }
            }
        }
         public void RetrieveAllStaff()
        {
            if(supportList.Count ==0)
           {
               Console.WriteLine("List is empty\n");
           }
            else{
             Console.WriteLine("Details are :\n");
             foreach(var support in supportList)
            {
               Console.WriteLine("\nId :"+support.Id+ "Name: "+support.Name+" "+"DOB: "+support.Dob+" "+"Phone :"+support.Phone+" "+"Email :"+support.Email+" Department: "+support.Department);
            }
            }
        }
        public  void RetrieveSingleStaff()
        {
            Console.WriteLine("Enter Details to Search :");
            Console.WriteLine("Enter ID :");
            inputId();
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            foreach(var support in supportList)
            {
                if(support.Id == Convert.ToInt32(id) && support.Name == name )
                {
                     Console.WriteLine("\nId :"+support.Id+" Name: "+support.Name+" "+"DOB: "+support.Dob+" "+"Phone :"+support.Phone+" "+"Email :"+support.Email+" Subject: "+support.Department);
                     return;                   
                }
            }
           Console.WriteLine("\nStaff Not Found !!");
        }



        public void EditHelp(SupportStaff support)
        {
            int option;
            Console.WriteLine("Edit Details of StaffId :"+support.Id);
                     do{
                         Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Subject\n6.Exit");
                         option = Convert.ToInt32(Console.ReadLine());
                         switch(option)
                         {
                             case 1: Console.WriteLine("Enter Name :");
                                     name = Console.ReadLine();
                                     support.Name = name;
                                     validation(support);
                                     Console.WriteLine("Edited Name :"+support.Name);
                                     break;
                            case 2:  Console.WriteLine("Enter Phone No:");
                                     phone = Console.ReadLine();
                                     support.Phone = phone;
                                     validation(support);
                                     Console.WriteLine("Edited Phone :"+support.Phone);
                                     break;
                            case 3: Console.WriteLine("Enter date of birth");
                                    dob = Console.ReadLine();
                                    support.Dob = dob;
                                    validation(support);
                                    Console.WriteLine("Edited Date of birth :"+support.Dob);
                                    break;
                            case 4: Console.WriteLine("Enter Email");
                                    email = Console.ReadLine();
                                    support.Email = email;
                                    validation(support);
                                    Console.WriteLine("Edited Email :"+support.Email);
                                    break;
                            case 5: Console.WriteLine("Enter Subject");
                                    department = Console.ReadLine();
                                    support.Department= subject;
                                    validation(support);
                                    Console.WriteLine("Edited Subject :"+support.Department);
                                    break;
                            case 6 : return;
                            default : Console.WriteLine("Invalid Input!!");
                                    break;

                         }
                     }
                     while(option!=6);
                     
                    
        }
        public void EditStaff()
        {
            
            Console.WriteLine("Enter Details of Staff to be Deleted :");
            Console.WriteLine("Enter ID :");
            inputId();
             foreach(var support in supportList)
            {
                 if(support.Id == Convert.ToInt32(id) )
                 {                     
                     EditHelp(support);                     
                 }
            }
            Console.WriteLine("\nStaff Not Found !!");

            

        }
        public void DeleteStaff()
        {
             Console.WriteLine("Enter Details to Search :");
            Console.WriteLine("Enter ID :");
            inputId();
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            foreach(var support in supportList)
            {
                if(support.Id == Convert.ToInt32(id) && support.Name == name )
                {
                     supportList.Remove(support);
                     Console.WriteLine("Successfully Deleted :\n"+"\nId :"+support.Id+" Name: "+support.Name+" "+"DOB: "+support.Dob+" "+"Phone :"+support.Phone+" "+"Email :"+support.Email+" Subject: "+support.Department);
                     return;                   
                }
            }
           Console.WriteLine("\nStaff Not Found !!");
        }
    }
}