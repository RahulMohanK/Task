using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
using FileOperationLibrary;
using DbOperationLibrary;
namespace OperationLibrary
{
    [DisplayName("Support Staff")]
    public class SupportStaffOperation : StaffOperation, IStaffOperation
    {
        static List<SupportStaff> supportList = new List<SupportStaff>();


        public void AddStaff()
        {
            string bulkOrNot = "n";
            do
            {
                string department = "";
                int Count = 0, Select, id = 0;
                bool valid = false;
                object[] opt = new object[5];
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
                    support.StaffType = SType.SupportStaff;
                    support.EmpId = opt[4].ToString();
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
                    jfile.AddToFile<SupportStaff>(support);
                    XmlFileOperation xfile = new XmlFileOperation();
                    xfile.AddToFile<SupportStaff>(support);

                    DatabaseOperation db = new DatabaseOperation();
                    db.AddBulkData(support.EmpId, support.Name, support.Phone, support.Email, support.Dob, (int)support.StaffType, support.Department);
                    //Console.WriteLine("\nValues added are :\n");

                    // Console.WriteLine("\nName: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Department: " + support.Department);
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
            string output = "";

            List<Staff> finalResult = new List<Staff>();

            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.RetrieveAllFromFile<SupportStaff>();
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.RetrieveAllFromFile<SupportStaff>();
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                finalResult = db.RetriveAll((int)SType.SupportStaff);

                foreach (var items in finalResult)
                {
                    SupportStaff item = (SupportStaff)items;
                    output = "EmpId : " + item.EmpId + " Name : " + item.Name + " Phone : " + item.Phone +
                                   " Email : " + item.Email + " Dob : " + item.Dob + " Designation : " + item.Department;
                    Console.WriteLine(output + "\n");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("\n List is empty \n");
            }

        }
        public void RetrieveSingleStaff()
        {

            string name = "", output = "";
            List<Staff> finalResult = new List<Staff>();
            object[] result = new object[7];
            Console.WriteLine("Enter Details to Search :");
            Console.WriteLine("Enter Name :");
            name = InputName();
            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.RetrieveFromFile<SupportStaff>(name);
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.RetrieveFromFile<SupportStaff>(name);

            DatabaseOperation db = new DatabaseOperation();
            finalResult = db.SearchStaff(name, (int)SType.SupportStaff);
            if (finalResult.Count > 0)
            {
                foreach (var items in finalResult)
                {
                    SupportStaff item = (SupportStaff)items;
                    output = "EmpId : " + item.EmpId + " Name : " + item.Name + " Phone : " + item.Phone +
                                   " Email : " + item.Email + " Dob : " + item.Dob + " Designation : " + item.Department;
                    Console.WriteLine(output + "\n");
                }

            }
            else
            {
                Console.WriteLine("\n List is empty \n");
            }

        }



        public void EditHelp(string id, SupportStaff support, SupportStaff supportEdit)
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
                            // JsonFileOperation jfile = new JsonFileOperation();
                            // jfile.UpdateFile<SupportStaff>(id, supportEdit);
                            // XmlFileOperation xfile = new XmlFileOperation();
                            // xfile.UpdateFile<SupportStaff>(id, supportEdit);
                            DatabaseOperation db = new DatabaseOperation();
                            db.UpdateStaff(supportEdit.EmpId, supportEdit.Name, supportEdit.Phone, supportEdit.Email, supportEdit.Dob, (int)supportEdit.StaffType, supportEdit.Department);
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

            string id;
            RetrieveAllStaff();
            Console.WriteLine("Enter details of staff to be edited:");
            Console.WriteLine("Enter EmpohId :");
            id = Console.ReadLine();

            SupportStaff support = new SupportStaff();
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                support = (SupportStaff)db.GetSingleStaff(id, (int)SType.SupportStaff);

                // JsonFileOperation jfile = new JsonFileOperation();
                // support = (SupportStaff)jfile.GetObj<SupportStaff>(id, support);
                // XmlFileOperation xfile = new XmlFileOperation();
                // support = (SupportStaff)xfile.GetObj<SupportStaff>(id, support);
                if (support.Name == null)
                {
                    Console.WriteLine("\nStaff Not Found !!");
                }
                else
                {
                    SupportStaff supportEdit = new SupportStaff();
                    supportEdit.StaffType = SType.SupportStaff;
                    supportEdit.EmpId = support.EmpId;
                    supportEdit.Name = support.Name;
                    supportEdit.Phone = support.Phone;
                    supportEdit.Dob = support.Dob;
                    supportEdit.Email = support.Email;
                    supportEdit.Department = support.Department;
                    EditHelp(id, support, supportEdit);


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
            SupportStaff result = new SupportStaff();
            //int id = 0; //iterator = 0;
            RetrieveAllStaff();
            Console.WriteLine("\nEnter Details to Delete :");

            Console.WriteLine("Enter EmpId:");
            id = Console.ReadLine();
            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.DeleteFromFile<SupportStaff>(id);
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.DeleteFromFile<SupportStaff>(id);
            DatabaseOperation dbr = new DatabaseOperation();
            result = (SupportStaff)dbr.GetSingleStaff(id, (int)SType.SupportStaff);
            if (result != null)
            {
                DatabaseOperation db = new DatabaseOperation();
                db.DeleteStaff((int)SType.SupportStaff, id);
                Console.WriteLine("\nDeleted Successfull");
            }
            else
            {
                Console.WriteLine("\nStaff Not Found !!");
            }

        }
    }
}