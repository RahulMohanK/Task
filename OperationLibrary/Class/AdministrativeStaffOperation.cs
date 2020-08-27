using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
using FileOperationLibrary;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using DbOperationLibrary;

namespace OperationLibrary
{
    [DisplayName("Administrative Staff")]
    public class AdministrativeStaffOperation : StaffOperation, IStaffOperation
    {
        static List<AdministrativeStaff> administrativeList = new List<AdministrativeStaff>();

        public void AddStaff()
        {

            string bulkOrNot = "n";

            do
            {

                string designation = "";
                int Count = 0, Select, id = 0;
                bool valid = false;
                object[] opt = new object[5];
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
                    admin.StaffType = SType.AdministrativeStaff;
                    admin.EmpId = opt[4].ToString();
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

                    // administrativeList.Add(admin);
                    JsonFileOperation jfile = new JsonFileOperation();
                    jfile.AddToFile<AdministrativeStaff>(admin);
                    XmlFileOperation xfile = new XmlFileOperation();
                    xfile.AddToFile<AdministrativeStaff>(admin);
                    DatabaseOperation createtb = new DatabaseOperation();
                    createtb.CreateTable();
                    DatabaseOperation db = new DatabaseOperation();
                    db.AddBulkData(admin.EmpId, admin.Name, admin.Phone, admin.Email, admin.Dob, (int)admin.StaffType, admin.Designation);

                    //Console.WriteLine("\nValues added are :\n");
                    //Console.WriteLine("\nName: " + admin.Name + " " + "DOB: " + admin.Dob + " " + "Phone :" + admin.Phone + " " + "Email :" + admin.Email + " Designation: " + admin.Designation);
                }
                Console.WriteLine("Add data again : (y/n)\n");
                bulkOrNot = Console.ReadLine();
                if (bulkOrNot.Equals("n"))
                {
                    DatabaseOperation database = new DatabaseOperation();
                    database.ExecuteBulkProc();
                    break;
                }
            }
            while (bulkOrNot.Equals("y"));

        }
        public void RetrieveAllStaff()
        {
            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.RetrieveAllFromFile<AdministrativeStaff>();
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.RetrieveAllFromFile<AdministrativeStaff>();
            DatabaseOperation db = new DatabaseOperation();
            db.RetriveAll((int)SType.AdministrativeStaff);





        }
        public void RetrieveSingleStaff()
        {

            string name = "";
            Console.WriteLine("Enter Details to Search :");

            Console.WriteLine("Enter Name :");

            name = InputName();

            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.RetrieveFromFile<AdministrativeStaff>(name);
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.RetrieveFromFile<AdministrativeStaff>(name);
            DatabaseOperation db = new DatabaseOperation();
            db.SearchStaff(name, (int)SType.AdministrativeStaff);

        }
        public void EditHelp(string id, AdministrativeStaff admin, AdministrativeStaff adminEdit)
        {
            int option;
            bool valid = false;
            string name = "", phone = "", email = "", designation = "", date = "";
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
                            // JsonFileOperation jfile = new JsonFileOperation();
                            // jfile.UpdateFile<AdministrativeStaff>(id, adminEdit);
                            // XmlFileOperation xfile = new XmlFileOperation();
                            // xfile.UpdateFile<AdministrativeStaff>(id, adminEdit);
                            DatabaseOperation db = new DatabaseOperation();
                            db.UpdateStaff(adminEdit.EmpId, adminEdit.Name, adminEdit.Phone, adminEdit.Email, adminEdit.Dob, (int)adminEdit.StaffType, adminEdit.Designation);
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
            object[] result = new object[6];
            string id;

            RetrieveAllStaff();
            Console.WriteLine("Enter details of staff to be edited:");
            Console.WriteLine("Enter EmpId :");
            id = Console.ReadLine();

            AdministrativeStaff admin = new AdministrativeStaff();
            // JsonFileOperation jfile = new JsonFileOperation();
            // admin = (AdministrativeStaff)jfile.GetObj<AdministrativeStaff>(id, admin);
            // XmlFileOperation xfile = new XmlFileOperation();
            // admin = (AdministrativeStaff)xfile.GetObj<AdministrativeStaff>(id);
            //Console.WriteLine("Name " + admin.Designation);
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                result = db.GetSingleStaff(id, (int)SType.AdministrativeStaff);
                admin.EmpId = result[0].ToString();
                admin.Name = result[1].ToString();
                admin.Phone = result[2].ToString();
                admin.Email = result[3].ToString();
                admin.Dob = (DateTime)result[4];
                admin.Designation = result[5].ToString();
                // Console.WriteLine("Name " + result[0].ToString());
                if (admin.Name == null)
                {
                    Console.WriteLine("\nStaff Not Found !!");
                }
                else
                {
                    AdministrativeStaff adminEdit = new AdministrativeStaff();
                    adminEdit.StaffType = SType.AdministrativeStaff;
                    adminEdit.EmpId = admin.EmpId;
                    adminEdit.Name = admin.Name;
                    adminEdit.Phone = admin.Phone;
                    adminEdit.Email = admin.Email;
                    adminEdit.Dob = admin.Dob;
                    adminEdit.Designation = admin.Designation;
                    EditHelp(id, admin, adminEdit);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nStaff Not Found !!");
            }




        }
        public void DeleteStaff()
        {
            string id;
            object[] result = new object[6];
            RetrieveAllStaff();
            Console.WriteLine("\nEnter Details to Delete :");

            Console.WriteLine("Enter EmpId:");
            id = Console.ReadLine();
            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.DeleteFromFile<AdministrativeStaff>(id);
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.DeleteFromFile<AdministrativeStaff>(id);

            DatabaseOperation dbr = new DatabaseOperation();
            result = dbr.GetSingleStaff(id, (int)SType.AdministrativeStaff);
            if (result[0] != null)
            {
                DatabaseOperation db = new DatabaseOperation();
                db.DeleteFromDb((int)SType.AdministrativeStaff, id);
                Console.WriteLine("\nDeletion Successfull");
            }
            else
            {
                Console.WriteLine("\nStaff Not Found !!");
            }
        }

    }
}