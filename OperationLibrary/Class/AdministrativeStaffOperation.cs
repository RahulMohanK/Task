using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary
{
     public class AdministrativeStaffOperation : StaffOperation
    {
        static List<AdministrativeStaff> administrativeList = new List<AdministrativeStaff>();

         public override void EnterValues()
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

            Console.WriteLine("Enter Email");
            email = Console.ReadLine();

            Console.WriteLine("Enter Designation");
            designation = Console.ReadLine();
        }
        public override void AddStaff()
        {
            
           
            AdministrativeStaff admin = new AdministrativeStaff();
            admin.Id=Convert.ToInt32(id);
            admin.Name=name;
            admin.Phone=long.Parse(phone);
            admin.Dob=dob;
            admin.Email = email;
            admin.Designation=designation;
            
            if(admin!=null)
            {
            administrativeList.Add(admin);
            Console.WriteLine("\nValues added are :\n");
            Console.WriteLine("\nId :"+admin.Id+" Name: "+admin.Name+" "+"DOB: "+admin.Dob+" "+"Phone :"+admin.Phone+" "+"Email :"+admin.Email+" Designation: "+admin.Designation);
            
            }
        }
         public override void RetrieveAllStaff()
        {
            if(administrativeList.Count == 0)
           {
               Console.WriteLine("List is empty\n");
           }
           else{
                 Console.WriteLine("Details are :\n");
                foreach(var admin in administrativeList)
            {
                 Console.WriteLine("\nId :"+admin.Id+" Name: "+admin.Name+" "+"DOB: "+admin.Dob+" "+"Phone :"+admin.Phone+" "+"Email :"+admin.Email+" Designation: "+admin.Designation);
            }
           }
            
        }
        public override void RetrieveSingleStaff()
        {
            Console.WriteLine("Enter Details to Search :");
            Console.WriteLine("Enter ID :");
            id = Console.ReadLine();
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            foreach(var admin in administrativeList)
            {
                if(admin.Id == Convert.ToInt32(id) && admin.Name == name )
                {
                     Console.WriteLine("\nId :"+admin.Id+" Name: "+admin.Name+" "+"DOB: "+admin.Dob+" "+"Phone :"+admin.Phone+" "+"Email :"+admin.Email+" Subject: "+admin.Designation);
                     return;                   
                }
            }
           Console.WriteLine("\nStaff Not Found !!");

        }
        public void EditHelp(AdministrativeStaff admin)
        {
            int option;
            Console.WriteLine("Edit Details of StaffId :"+admin.Id);
                     do{
                         Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Subject\n6.Exit");
                         option = Convert.ToInt32(Console.ReadLine());
                         switch(option)
                         {
                             case 1: Console.WriteLine("Enter Name :");
                                     name = Console.ReadLine();
                                     admin.Name = name;
                                     Console.WriteLine("Edited Name :"+admin.Name);
                                     break;
                            case 2:  Console.WriteLine("Enter Phone No:");
                                     phone = Console.ReadLine();
                                     admin.Phone = long.Parse(phone);
                                     Console.WriteLine("Edited Phone :"+admin.Phone);
                                     break;
                            case 3: Console.WriteLine("Enter date of birth");
                                    dob = Console.ReadLine();
                                    admin.Dob = dob;
                                    Console.WriteLine("Edited Date of birth :"+admin.Dob);
                                    break;
                            case 4: Console.WriteLine("Enter Email");
                                    email = Console.ReadLine();
                                    admin.Email = email;
                                    Console.WriteLine("Edited Email :"+admin.Email);
                                    break;
                            case 5: Console.WriteLine("Enter Subject");
                                    designation = Console.ReadLine();
                                    admin.Designation = designation;
                                    Console.WriteLine("Edited Subject :"+admin.Designation);
                                    break;
                            case 6 : return;
                            default : Console.WriteLine("Invalid Input!!");
                                    break;

                         }
                     }
                     while(option!=6);
                     
                    
        }
        public override void EditStaff()
        {
            
            Console.WriteLine("Enter Details of Staff to be Deleted :");
            Console.WriteLine("Enter ID :");
            id = Console.ReadLine();
             foreach(var admin in administrativeList)
            {
                 if(admin.Id == Convert.ToInt32(id) )
                 {                     
                     EditHelp(admin);                     
                 }
            }
            Console.WriteLine("\nStaff Not Found !!");

            

        }
        public override void DeleteStaff()
        {
            Console.WriteLine("Enter Details to Search :");
            Console.WriteLine("Enter ID :");
            id = Console.ReadLine();
            Console.WriteLine("Enter Name :");
            name = Console.ReadLine();

            foreach(var admin in administrativeList)
            {
                if(admin.Id == Convert.ToInt32(id) && admin.Name == name )
                {
                    administrativeList.Remove(admin);
                     Console.WriteLine("Successfully Deleted :\n"+"\nId :"+admin.Id+" Name: "+admin.Name+" "+"DOB: "+admin.Dob+" "+"Phone :"+admin.Phone+" "+"Email :"+admin.Email+" Subject: "+admin.Designation);
                     return;                   
                }
            }
           Console.WriteLine("\nStaff Not Found !!");
        }
    }
}