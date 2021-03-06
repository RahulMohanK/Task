using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
using FileOperationLibrary;
using DbOperationLibrary;
namespace OperationLibrary
{
    [DisplayName("Teaching Staff")]
    public class TeachingStaffOperation : StaffOperation, IStaffOperation
    {
        static List<TeachingStaff> teachingList = new List<TeachingStaff>();


        public void AddStaff()
        {
            string bulkOrNot = "n";
            do
            {
                string subject = "";
                int Count = 0, Select, id = 0;
                bool valid = false;
                object[] opt = new object[5];
                string[] Options;
                TeachingStaff teaching = new TeachingStaff();
                do
                {
                    opt = EnterValues();
                    Options = ConfigList("Subject");
                    Console.WriteLine("Enter Subject :");
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
                        subject = Options[Select - 1];
                        break;
                    }
                    while (Select != 0);
                    teaching.StaffType = SType.TeachingStaff;
                    teaching.EmpId = opt[4].ToString();
                    teaching.Name = opt[0].ToString();
                    teaching.Phone = opt[1].ToString();
                    if (!String.IsNullOrEmpty(opt[2].ToString()))
                    {
                        teaching.Dob = Convert.ToDateTime(opt[2]);
                    }
                    teaching.Email = opt[3].ToString();
                    teaching.Subject = subject;
                    valid = Validation(teaching);
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
                    teachingList.Add(teaching);
                    // JsonFileOperation jfile = new JsonFileOperation();
                    // jfile.AddToFile<TeachingStaff>(teaching);
                    // XmlFileOperation xfile = new XmlFileOperation();
                    // xfile.AddToFile<TeachingStaff>(teaching);

                    DatabaseOperation db = new DatabaseOperation();
                    db.AddBulkData(teaching.EmpId, teaching.Name, teaching.Phone, teaching.Email, teaching.Dob, (int)teaching.StaffType, teaching.Subject);

                    // Console.WriteLine("\nValues added are :\n");
                    //Console.WriteLine("\nName: " + teaching.Name + " " + "DOB: " + teaching.Dob + " " + "Phone :" + teaching.Phone + " " + "Email :" + teaching.Email + " Subject: " + teaching.Subject);
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
            // xfile.RetrieveAllFromFile<TeachingStaff>();
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                finalResult = db.RetriveAll((int)SType.TeachingStaff);

                foreach (var items in finalResult)
                {
                    TeachingStaff item = (TeachingStaff)items;
                    output = "EmpId : " + item.EmpId + " Name : " + item.Name + " Phone : " + item.Phone +
                                   " Email : " + item.Email + " Dob : " + item.Dob + " Designation : " + item.Subject;
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
            // jfile.RetrieveFromFile<TeachingStaff>(name);

            // XmlFileOperation xfile = new XmlFileOperation();`
            // xfile.RetrieveFromFile<TeachingStaff>(name);

            DatabaseOperation db = new DatabaseOperation();
            finalResult = db.SearchStaff(name, (int)SType.TeachingStaff);
            if (finalResult.Count > 0)
            {
                foreach (var items in finalResult)
                {
                    TeachingStaff item = (TeachingStaff)items;
                    output = "EmpId : " + item.EmpId + " Name : " + item.Name + " Phone : " + item.Phone +
                                   " Email : " + item.Email + " Dob : " + item.Dob + " Designation : " + item.Subject;
                    Console.WriteLine(output + "\n");
                }

            }
            else
            {
                Console.WriteLine("\n List is empty \n");
            }


        }
        public void EditHelp(string id, TeachingStaff teaching, TeachingStaff teachingEdit)
        {

            int option;
            bool valid = false;
            string name = "", phone = "", email = "", subject = "", date = "";

            string[] Options;
            int Select, Count = 0;
            Console.WriteLine("Edit Details of Staff :" + teaching.Name);
            do
            {
                Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Subject\n6.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name :");
                        name = Console.ReadLine();
                        teachingEdit.Name = name;
                        valid = Validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Name :" + teachingEdit.Name);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Phone No:");
                        phone = Console.ReadLine();
                        teachingEdit.Phone = phone;
                        valid = Validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Phone :" + teachingEdit.Phone);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter date of birth");

                        date = InputDob();
                        if (!String.IsNullOrEmpty(date))
                        {
                            teachingEdit.Dob = Convert.ToDateTime(date);
                        }
                        valid = Validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Date of birth :" + teaching.Dob);
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                        teachingEdit.Email = email;
                        valid = Validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Email :" + teachingEdit.Email);
                        }

                        break;
                    case 5:
                        Options = ConfigList("Subject");
                        Console.WriteLine("Enter Subject");
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
                            subject = Options[Select - 1];
                            break;
                        }
                        while (Select != 0);
                        teachingEdit.Subject = subject;
                        valid = Validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Subject :" + teachingEdit.Subject);
                        }

                        break;
                    case 6:
                        valid = Validation(teachingEdit);
                        if (!valid)
                        {
                            Console.WriteLine("Values Not Edited");
                            return;
                        }
                        else if (teaching == teachingEdit)
                        {
                            return;
                        }
                        else
                        {
                            // JsonFileOperation jfile = new JsonFileOperation();
                            // jfile.UpdateFile<TeachingStaff>(id, teachingEdit);
                            // XmlFileOperation xfile = new XmlFileOperation();
                            // xfile.UpdateFile<TeachingStaff>(id, teachingEdit);
                            DatabaseOperation db = new DatabaseOperation();
                            db.UpdateStaff(teachingEdit.EmpId, teachingEdit.Name, teachingEdit.Phone, teachingEdit.Email, teachingEdit.Dob, (int)teachingEdit.StaffType, teachingEdit.Subject);
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
            Console.WriteLine("Enter EmpId :");
            id = Console.ReadLine();

            TeachingStaff teaching = new TeachingStaff();
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                teaching = (TeachingStaff)db.GetSingleStaff(id, (int)SType.TeachingStaff);

                // JsonFileOperation jfile = new JsonFileOperation();
                // teaching = (TeachingStaff)jfile.GetObj<TeachingStaff>(id, teaching);
                // XmlFileOperation xfile = new XmlFileOperation();
                // teaching = (TeachingStaff)xfile.GetObj<TeachingStaff>(id, teaching);


                if (teaching.Name == null)
                {
                    Console.WriteLine("\nStaff Not Found!!");
                }
                else
                {
                    TeachingStaff teachingEdit = new TeachingStaff();
                    teachingEdit.StaffType = SType.TeachingStaff;
                    teachingEdit.EmpId = teaching.EmpId;
                    teachingEdit.Name = teaching.Name;
                    teachingEdit.Phone = teaching.Phone;
                    teachingEdit.Dob = teaching.Dob;
                    teachingEdit.Email = teaching.Email;
                    teachingEdit.Subject = teaching.Subject;
                    EditHelp(id, teaching, teachingEdit);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nStaff Not Found!!");
            }



        }
        public void DeleteStaff()
        {
            string id;
            TeachingStaff result = new TeachingStaff();
            RetrieveAllStaff();
            Console.WriteLine("\nEnter Details to Delete :");

            Console.WriteLine("Enter EmpId:");
            id = Console.ReadLine();
            // JsonFileOperation jfile = new JsonFileOperation();
            // jfile.DeleteFromFile<TeachingStaff>(id);
            // XmlFileOperation xfile = new XmlFileOperation();
            // xfile.DeleteFromFile<TeachingStaff>(id);
            DatabaseOperation dbr = new DatabaseOperation();
            result = (TeachingStaff)dbr.GetSingleStaff(id, (int)SType.TeachingStaff);
            if (result != null)
            {
                DatabaseOperation db = new DatabaseOperation();
                db.DeleteStaff((int)SType.TeachingStaff, id);
                Console.WriteLine("\nDeletion Successfull");
            }
            else
            {
                Console.WriteLine("\nStaff Not Found!!");
            }
        }


    }
}