using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel.DataAnnotations;
namespace OperationLibrary
{
    public class AdministrativeStaffOperation : StaffOperation, IStaffOperation
    {
        static List<AdministrativeStaff> administrativeList = new List<AdministrativeStaff>();
        public void AddStaff()
        {
            AdministrativeStaff admin = new AdministrativeStaff();
            do{
            
            EnterValues();
            Options = configList("Designation");
            Console.WriteLine("Enter Designation :");
            do
            {
                Console.WriteLine("\nSelect any one option(0 to exit)");

                foreach (var val in Options)
                    Console.WriteLine(++Count + " :" + val);
                Count =0;

                int.TryParse(Console.ReadLine(), out Select);
                if (Select == 0)
                {
                    break;
                }
                designation = Options[Select - 1];
                break;
            }
            while (Select != 0);
            
            admin.Name = name;
            admin.Phone = phone;
            admin.Dob = dob;
            admin.Email = email;
            admin.Designation = designation;
            validation(admin);
            if(!valid)
            {Console.WriteLine("\nDo you want to correct entered values ??(yes-1/No-0)");
            inputOption();
             if(id == 1)
             {
                 continue;
             }
             else{break;}
            }
        }
        while(!valid);
        if(valid)
        {
             administrativeList.Add(admin);
             Console.WriteLine("\nValues added are :\n");
             Console.WriteLine("\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Designation: " + admin.Designation);
        }
    
        }
        public void RetrieveAllStaff()
        {
            if (administrativeList.Count == 0)
            {
                Console.WriteLine("List is empty\n");
            }
            else
            {
                Console.WriteLine("Details are :\n");
                foreach (var admin in administrativeList)
                {
                    Console.WriteLine("\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Designation: " + admin.Designation);
                }
            }

        }
        public void RetrieveSingleStaff()
        {
            Console.WriteLine("Enter Details to Search :");
          
            Console.WriteLine("Enter Name :");
           
            inputName();

            foreach (var admin in administrativeList)
            {
                if (admin.Name == name)
                {
                    Console.WriteLine("\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Subject: " + admin.Designation);
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found !!");

        }
        public void EditHelp(AdministrativeStaff admin, AdministrativeStaff adminEdit)
        {
            int option;
            Console.WriteLine("Edit Details of Staff:" + admin.Name);
            do
            {
                Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Subject\n6.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name :");
                        name = Console.ReadLine();
                        adminEdit.Name = name;
                        validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Name :" + adminEdit.Name);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Phone No:");
                        phone = Console.ReadLine();
                        adminEdit.Phone = phone;
                        validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine("Phone No:" + adminEdit.Phone);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter date of birth");
                        inputDob();
                       
                        adminEdit.Dob = dob;
                        validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Date of birth :" + adminEdit.Dob);
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                        adminEdit.Email = email;
                        validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Email Address :" + adminEdit.Email);
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Subject");
                        designation = Console.ReadLine();
                        adminEdit.Designation = designation;
                        validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine("Subject  :" + adminEdit.Designation);
                        }

                        break;
                    case 6:
                        validation(adminEdit);
                        if (!valid)
                        {
                            Console.WriteLine("Values Not Edited");
                            return;
                        }
                        else if (admin == adminEdit)
                        {
                            return;
                        }
                        else
                        {
                            administrativeList.Remove(admin);
                            administrativeList.Add(adminEdit);
                            Console.WriteLine("Edit Successfull");
                            return;
                        }
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }
            while (option != 6);


        }
        public void EditStaff()
        {
            bool flag = false;
            Console.WriteLine("Enter Details of Staff to be Deleted :");
            Console.WriteLine("Enter Name :");
           
            inputName();
            foreach (var admin in administrativeList)
            {
                if (admin.Name == name)
                {
                    AdministrativeStaff adminEdit = new AdministrativeStaff();
                   
                    adminEdit.Name = admin.Name;
                    adminEdit.Phone = admin.Phone;
                    adminEdit.Email = admin.Email;
                    adminEdit.Dob = admin.Dob;
                    adminEdit.Designation = admin.Designation;
                    EditHelp(admin, adminEdit);
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("\nStaff Not Found !!");
            }
        }
        public void DeleteStaff()
        {
            Console.WriteLine("Enter Details to Search :");
            
            Console.WriteLine("Enter Name :");
            
            inputName();

            foreach (var admin in administrativeList)
            {
                if (admin.Name == name)
                {
                    administrativeList.Remove(admin);
                    Console.WriteLine("Successfully Deleted :\n" +"\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Subject: " + admin.Designation);
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found !!");
        }

    }
}