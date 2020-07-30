using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
using FileOperationLibrary;
namespace OperationLibrary
{
    [DisplayName("Support Staff")]
    public class SupportStaffOperation : StaffOperation, IStaffOperation
    {
        static List<SupportStaff> supportList = new List<SupportStaff>();

        public void AddStaff()
        {
            string department = "";
            int Count = 0, Select, id = 0;
            bool valid = false;
            object[] opt = new object[4];
            string[] Options;
            SupportStaff support = new SupportStaff();
            do
            {
                opt = EnterValues();
                Options = ConfigList("Department");
                Console.WriteLine("Enter Department :");
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
                    department = Options[Select - 1];
                    break;
                }
                while (Select != 0);
                support.Name = opt[0].ToString();
                support.Phone = opt[1].ToString();
                if (!String.IsNullOrEmpty(opt[2].ToString()))
                {
                    support.Dob = Convert.ToDateTime(opt[2]);
                }
                support.Email = opt[3].ToString();
                support.Department = department;
                valid = Validation(support);
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
                supportList.Add(support);
                JsonFileOperation jfile = new JsonFileOperation();
                jfile.AddToFile(support, "Support Staff");
                Console.WriteLine("\nValues added are :\n");

                Console.WriteLine("\nName: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Department: " + support.Department);
            }


        }
        public void RetrieveAllStaff()
        {
            JsonFileOperation jfile = new JsonFileOperation();
            jfile.RetrieveAllFromFile("Support Staff");
            // int k = 0;
            // if (supportList.Count == 0)
            // {
            //     Console.WriteLine("List is empty\n");
            // }
            // else
            // {
            //     Console.WriteLine("\nDetails are :");
            //     foreach (var support in supportList)
            //     {
            //         Console.WriteLine("\nId: " + (++k) + "Name: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Department: " + support.Department);
            //     }
            // }
        }
        public void RetrieveSingleStaff()
        {
            string name = "";
            Console.WriteLine("Enter Details to Search :");
            Console.WriteLine("Enter Name :");
            name = InputName();
            JsonFileOperation jfile = new JsonFileOperation();
            jfile.RetrieveFromFile(name, "Support Staff");

            // foreach (var support in supportList)
            // {
            //     if (support.Name == name)
            //     {
            //         Console.WriteLine("\nName: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Subject: " + support.Department);
            //         return;
            //     }
            // }
            // Console.WriteLine("\nStaff Not Found !!");
        }



        public void EditHelp(int id, SupportStaff support, SupportStaff supportEdit)
        {
            int option;
            bool valid = false;
            string name = "", phone = "", email = "", department = "", date = "";
            string[] Options;
            int Select, Count = 0;
            Console.WriteLine("Edit Details of Staff :" + support.Name);
            do
            {
                Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Department\n6.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name :");
                        name = Console.ReadLine();
                        supportEdit.Name = name;
                        valid = Validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Name :" + supportEdit.Name);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Phone No:");
                        phone = Console.ReadLine();
                        supportEdit.Phone = phone;
                        valid = Validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Phone :" + supportEdit.Phone);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter date of birth");
                        date = InputDob();
                        if (!String.IsNullOrEmpty(date))
                        {
                            supportEdit.Dob = Convert.ToDateTime(date);
                        }

                        valid = Validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Date of birth :" + supportEdit.Dob);
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                        supportEdit.Email = email;
                        valid = Validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Email :" + supportEdit.Email);
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Department");
                        Options = ConfigList("Department");
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
                            department = Options[Select - 1];
                            break;
                        }
                        while (Select != 0);
                        supportEdit.Department = department;
                        valid = Validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Department:" + supportEdit.Department);
                        }

                        break;
                    case 6:
                        valid = Validation(supportEdit);
                        if (!valid)
                        {
                            Console.WriteLine("Values Not Edited");
                            return;
                        }
                        else if (support == supportEdit)
                        {
                            return;
                        }
                        else
                        {
                            JsonFileOperation jfile = new JsonFileOperation();
                            jfile.UpdateFile(id, "Support Staff", supportEdit);
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
            // bool flag = false;
            int id = 0;
            //, iterator = 0;
            RetrieveAllStaff();
            Console.WriteLine("Enter details of staff to be edited:");
            Console.WriteLine("Enter Id :");
            id = InputOption();

            SupportStaff support = new SupportStaff();
            JsonFileOperation jfile = new JsonFileOperation();
            support = (SupportStaff)jfile.GetObj<SupportStaff>(id, "Support Staff", support);
            if (support.Name == null)
            {
                Console.WriteLine("\nStaff Not Found !!");
            }
            else
            {
                SupportStaff supportEdit = new SupportStaff();
                supportEdit.Name = support.Name;
                supportEdit.Phone = support.Phone;
                supportEdit.Dob = support.Dob;
                supportEdit.Email = support.Email;
                supportEdit.Department = support.Department;
                EditHelp(id, support, supportEdit);
                //flag = true;

            }
        }



        public void DeleteStaff()
        {

            int id = 0; //iterator = 0;
            RetrieveAllStaff();
            Console.WriteLine("\nEnter Details to Delete :");

            Console.WriteLine("Enter id:");
            id = InputOption();
            JsonFileOperation jfile = new JsonFileOperation();
            jfile.DeleteFromFile(id, "Support Staff");
            // foreach (var support in supportList)
            // {
            //     ++iterator;
            //     if (id == iterator)
            //     {
            //         supportList.Remove(support);
            //         Console.WriteLine("Successfully Deleted :\n" + " Name: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Subject: " + support.Department);
            //         return;
            //     }
            // }
            // Console.WriteLine("\nStaff Not Found !!");
        }
    }
}