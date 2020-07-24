using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel.DataAnnotations;
namespace OperationLibrary
{

     public class TeachingStaffOperation: IStaffOperation
    {
        public string name ,subject,email,dob,phone,designation,department; 
        public int id;
        bool parseSuccess;
        public static bool valid;
        static List<TeachingStaff> teachingList = new List<TeachingStaff>();
    
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
         public void validation(TeachingStaff teaching)
         {
            ValidationContext context = new ValidationContext(teaching,null,null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            valid = Validator.TryValidateObject(teaching,context,validationResults,true);
            if(!valid)
            {
                foreach(ValidationResult validation in validationResults)
                {
                    Console.WriteLine(validation.ErrorMessage);
                }
            }
         }
        public  void EnterValues()
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
            Console.WriteLine("Enter Subject :");
            subject = Console.ReadLine();
        }
        public  void AddStaff()
        {
            EnterValues();
            TeachingStaff teaching = new TeachingStaff();
            teaching.Id=id;
            teaching.Name=name;
            teaching.Phone=phone;
            teaching.Dob=dob;
            teaching.Email = email;
            teaching.Subject=subject;
            
           
            
            if(teaching!=null)
            {
            ValidationContext context = new ValidationContext(teaching,null,null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            valid = Validator.TryValidateObject(teaching,context,validationResults,true);
            if(!valid)
            {
                foreach(ValidationResult validation in validationResults)
                {
                    Console.WriteLine(validation.ErrorMessage);
                }
            }else{
            teachingList.Add(teaching);
            Console.WriteLine("\nValues added are :\n");
            Console.WriteLine("Id :"+teaching.Id+" Name: "+teaching.Name+" "+"DOB: "+teaching.Dob+" "+"Phone :"+teaching.Phone+" "+"Email :"+teaching.Email+" Subject: "+teaching.Subject);
            }
            }
        }

        public void RetrieveAllStaff()
        {
           
           if(teachingList.Count ==0)
           {
               Console.WriteLine("List is empty\n");
           }
           else
           {
            Console.WriteLine("Details are :\n");
            foreach(var teaching in teachingList)
            {
                Console.WriteLine("Id :"+teaching.Id+" Name: "+teaching.Name+" "+"DOB: "+teaching.Dob+" "+"Phone :"+teaching.Phone+" "+"Email :"+teaching.Email+" Subject: "+teaching.Subject);
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

            foreach(var teaching in teachingList)
            {
                if(teaching.Id == Convert.ToInt32(id) && teaching.Name == name )
                {
                     Console.WriteLine("\nId :"+teaching.Id+" Name: "+teaching.Name+" "+"DOB: "+teaching.Dob+" "+"Phone :"+teaching.Phone+" "+"Email :"+teaching.Email+" Subject: "+teaching.Subject);
                     return;                   
                }
            }
           Console.WriteLine("\nStaff Not Found !!");
        }
        public void EditHelp(TeachingStaff teaching)
        {
            int option;
            Console.WriteLine("Edit Details of StaffId :"+teaching.Id);
                     do{
                         Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Subject\n6.Exit");
                         option = Convert.ToInt32(Console.ReadLine());
                         switch(option)
                         {
                             case 1: Console.WriteLine("Enter Name :");
                                     name = Console.ReadLine();
                                     teaching.Name = name;
                                     validation(teaching);
                                     Console.WriteLine("Edited Name :"+teaching.Name);
                                     break;
                            case 2:  Console.WriteLine("Enter Phone No:");
                                     phone = Console.ReadLine();
                                     teaching.Phone = phone;
                                      validation(teaching);
                                     Console.WriteLine("Edited Phone :"+teaching.Phone);
                                     break;
                            case 3: Console.WriteLine("Enter date of birth");
                                    dob = Console.ReadLine();
                                    teaching.Dob = dob;
                                     validation(teaching);
                                    Console.WriteLine("Edited Date of birth :"+teaching.Dob);
                                    break;
                            case 4: Console.WriteLine("Enter Email");
                                    email = Console.ReadLine();
                                    teaching.Email = email;
                                     validation(teaching);
                                    Console.WriteLine("Edited Email :"+teaching.Email);
                                    break;
                            case 5: Console.WriteLine("Enter Subject");
                                    subject = Console.ReadLine();
                                    teaching.Subject = subject;
                                    validation(teaching);
                                    Console.WriteLine("Edited Subject :"+teaching.Subject);
                                    break;
                            case 6 : 
                                      
                                    return;
                                      
                                    
                            default : Console.WriteLine("Invalid Input!!");
                                    break;

                         }
                     }
                     while(option!=6 );
                     
                    
        }
        public  void EditStaff()
        {
            
            Console.WriteLine("Enter Details of Staff to be Deleted :");
            Console.WriteLine("Enter ID :");
            inputId();
             foreach(var teaching in teachingList)
            {
                 if(teaching.Id == Convert.ToInt32(id) )
                 {                     
                     EditHelp(teaching);                     
                 }
            }
            Console.WriteLine("\nStaff Not Found !!");

            

        }
        public void DeleteStaff()
        {
            Console.WriteLine("Enter Details of Staff to be Deleted :");
            Console.WriteLine("Enter ID :");
            inputId();
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();
            
            foreach(var teaching in teachingList)
            {
                if(teaching.Id == Convert.ToInt32(id) && teaching.Name == name )
                {
                     teachingList.Remove(teaching);
                     Console.WriteLine("Successfully Deleted :\n"+"\nId :"+teaching.Id+" Name: "+teaching.Name+" "+"DOB: "+teaching.Dob+" "+"Phone :"+teaching.Phone+" "+"Email :"+teaching.Email+" Subject: "+teaching.Subject);
                     return;                   
                }
            }
           Console.WriteLine("\nStaff Not Found !!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Teaching staff");
        }

    }
}