using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary
{
     public class SupportStaffOperation : StaffOperation
    {
        public string name ,subject,email,dob,phone,id,designation,department; 
        static List<SupportStaff> supportList = new List<SupportStaff>();

        public  void EnterValues()
        {
             Console.WriteLine("Enter Details :");
            Console.WriteLine("Enter Id:");
            id = Console.ReadLine();

            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            Console.WriteLine("Enter Phone No:");
            phone = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            dob = Console.ReadLine();

            Console.WriteLine("Enter Email :");
            email = Console.ReadLine();

            Console.WriteLine("Enter Department :");
            department = Console.ReadLine();
        }
         public  void AddStaff()
        {
           
           
            SupportStaff support= new SupportStaff();
            support.Id=Convert.ToInt32(id);
            support.Name=name;
            support.Phone=long.Parse(phone);
            support.Dob=dob;
            support.Email = email;
            support.Department=department;
           
             if(support!=null)
            {
            supportList.Add(support);
            Console.WriteLine("\nValues added are :\n");
    
            Console.WriteLine("Id :"+support.Id+ " Name: "+support.Name+" "+"DOB: "+support.Dob+" "+"Phone :"+support.Phone+" "+"Email :"+support.Email+" Department: "+support.Department);
            
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
            id = Console.ReadLine();
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
                                     Console.WriteLine("Edited Name :"+support.Name);
                                     break;
                            case 2:  Console.WriteLine("Enter Phone No:");
                                     phone = Console.ReadLine();
                                     support.Phone = long.Parse(phone);
                                     Console.WriteLine("Edited Phone :"+support.Phone);
                                     break;
                            case 3: Console.WriteLine("Enter date of birth");
                                    dob = Console.ReadLine();
                                    support.Dob = dob;
                                    Console.WriteLine("Edited Date of birth :"+support.Dob);
                                    break;
                            case 4: Console.WriteLine("Enter Email");
                                    email = Console.ReadLine();
                                    support.Email = email;
                                    Console.WriteLine("Edited Email :"+support.Email);
                                    break;
                            case 5: Console.WriteLine("Enter Subject");
                                    department = Console.ReadLine();
                                    support.Department= subject;
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
            id = Console.ReadLine();
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
            id = Console.ReadLine();
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