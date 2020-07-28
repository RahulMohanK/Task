using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
namespace OperationLibrary
{
    [DisplayName("Administrative Staff")]
    public class AdministrativeStaffOperation : StaffOperation, IStaffOperation
    {
        static List<AdministrativeStaff> administrativeList = new List<AdministrativeStaff>();
        public void AddStaff()
        {
            string designation = "";
            int Count = 0, Select, id = 0;
            bool valid = false;
            object[] opt = new object[4];
            string[] Options;
            AdministrativeStaff admin = new AdministrativeStaff();
            do
            {

                opt = EnterValues();

                Options = ConfigList("Designation");
                Console.WriteLine("Enter Designation :");
                do
                {
                    Console.WriteLine("\nSelect any one option(0 to exit)");

                    foreach (var val in Options)
                        Console.WriteLine(++Count + " :" + val);
                    Count = 0;

                    int.TryParse(Console.ReadLine(), out Select);
                    if (Select == 0)
                    {
                        break;
                    }
                    designation = Options[Select - 1];
                    break;
                }
                while (Select != 0);

                admin.Name = opt[0].ToString();
                admin.Phone = opt[1].ToString();
                admin.Email = opt[3].ToString();
                admin.Designation = designation;

                if (!String.IsNullOrEmpty(opt[2].ToString()))
                {
                    admin.Dob = Convert.ToDateTime(opt[2]);
                }


                valid = Validation(admin);
                if (!valid)
                {
                    Console.WriteLine("\nDo you want to correct entered values ??(yes-1/No-0)");
                    id = InputOption();
                    if (id == 1)
                    {
                        continue;
                    }
                    else { break; }
                }
            }
            while (!valid);
            if (valid)
            {
                administrativeList.Add(admin);
                Console.WriteLine("\nValues added are :\n");
                Console.WriteLine("\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Designation: " + admin.Designation);
            }

        }
        public void RetrieveAllStaff()
        {
            int k = 0;
            if (administrativeList.Count == 0)
            {
                Console.WriteLine("List is empty\n");
            }
            else
            {
                Console.WriteLine("\nDetails are :");
                foreach (var admin in administrativeList)
                {
                    Console.WriteLine("\nId: " + (++k) + " Name: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Designation: " + admin.Designation);
                }
            }

        }
        public void RetrieveSingleStaff()
        {
            string name = "";
            Console.WriteLine("Enter Details to Search :");

            Console.WriteLine("Enter Name :");

            name = InputName();

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
            bool valid = false;
            string name = "", phone = "", email = "", designation = "", date = "";
            // DateTime date = DateTime.Now;
            string[] Options;
            int Select, Count = 0;
            Console.WriteLine("Edit Details of Staff:" + admin.Name);
            do
            {
                Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Designation\n6.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name :");
                        name = Console.ReadLine();
                        adminEdit.Name = name;
                        valid = Validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Name :" + adminEdit.Name);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Phone No:");
                        phone = Console.ReadLine();
                        adminEdit.Phone = phone;
                        valid = Validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine("Phone No:" + adminEdit.Phone);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter date of birth");
                        date = InputDob();
                        if (!String.IsNullOrEmpty(date))
                        {
                            adminEdit.Dob = Convert.ToDateTime(date);
                        }
                        valid = Validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Date of birth :" + adminEdit.Dob);
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                        adminEdit.Email = email;
                        valid = Validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Email Address :" + adminEdit.Email);
                        }

                        break;
                    case 5:
                        Options = ConfigList("Designation");
                        Console.WriteLine("Enter Designation");
                        do
                        {
                            Console.WriteLine("\nSelect any one option(0 to exit)");

                            foreach (var val in Options)
                                Console.WriteLine(++Count + " :" + val);
                            Count = 0;

                            int.TryParse(Console.ReadLine(), out Select);
                            if (Select == 0)
                            {
                                break;
                            }
                            designation = Options[Select - 1];
                            break;
                        }
                        while (Select != 0);
                        adminEdit.Designation = designation;
                        valid = Validation(adminEdit);
                        if (valid)
                        {
                            Console.WriteLine("Designation :" + adminEdit.Designation);
                        }

                        break;
                    case 6:
                        valid = Validation(adminEdit);
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

            int id = 0, iterator = 0;
            RetrieveAllStaff();
            Console.WriteLine("Enter details of staff to be edited:");
            Console.WriteLine("Enter Id :");
            id = InputOption();

            foreach (var admin in administrativeList)
            {
                ++iterator;
                if (iterator == id)
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

            int id = 0, iterator = 0;
            RetrieveAllStaff();
            Console.WriteLine("\nEnter Details to Delete :");

            Console.WriteLine("Enter id:");
            id = InputOption();

            foreach (var admin in administrativeList)
            {
                ++iterator;
                if (id == iterator)
                {
                    administrativeList.Remove(admin);
                    Console.WriteLine("Successfully Deleted :" + "\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Subject: " + admin.Designation);
                    return;
                }
            }

            Console.WriteLine("\nStaff Not Found !!");
        }

    }
}