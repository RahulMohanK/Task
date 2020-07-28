using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel.DataAnnotations;
namespace OperationLibrary
{
    public class SupportStaffOperation : StaffOperation, IStaffOperation
    {
        static List<SupportStaff> supportList = new List<SupportStaff>();

        public void AddStaff()
        {
            SupportStaff support = new SupportStaff();
            do{
            EnterValues();
            Options = configList("Department");
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
            
           
            // support.Id = id;
            support.Name = name;
            support.Phone = phone;
            support.Dob = dob;
            support.Email = email;
            support.Department = department;
            validation(support);
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
                 supportList.Add(support);
                    Console.WriteLine("\nValues added are :\n");

                    Console.WriteLine("\nName: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Department: " + support.Department);
            }

            // if (support != null)
            // {
            //     ValidationContext context = new ValidationContext(support, null, null);
            //     List<ValidationResult> validationResults = new List<ValidationResult>();
            //     valid = Validator.TryValidateObject(support, context, validationResults, true);
            //     if (!valid)
            //     {
            //         foreach (ValidationResult validation in validationResults)
            //         {
            //             Console.WriteLine(validation.ErrorMessage);
            //         }
            //     }
            //     else
            //     {
            //         supportList.Add(support);
            //         Console.WriteLine("\nValues added are :\n");

            //         Console.WriteLine("Id :" + support.Id + " Name: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Department: " + support.Department);
            //     }
            // }
        }
        public void RetrieveAllStaff()
        {
            if (supportList.Count == 0)
            {
                Console.WriteLine("List is empty\n");
            }
            else
            {
                Console.WriteLine("Details are :\n");
                foreach (var support in supportList)
                {
                    Console.WriteLine("\nName: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Department: " + support.Department);
                }
            }
        }
        public void RetrieveSingleStaff()
        {
            Console.WriteLine("Enter Details to Search :");
            // Console.WriteLine("Enter ID :");
            // inputId();
            Console.WriteLine("Enter Name :");
            //name = Console.ReadLine();
            inputName();

            foreach (var support in supportList)
            {
                if (support.Name == name)
                {
                    Console.WriteLine("\nName: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Subject: " + support.Department);
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found !!");
        }



        public void EditHelp(SupportStaff support, SupportStaff supportEdit)
        {
            int option;
            Console.WriteLine("Edit Details of Staff :" + support.Name);
            do
            {
                Console.WriteLine("Select Values (1/2/3/4/5/6) :\n1.Edit Name\n2.Edit Phone\n3.Edit Dob\n4.Edit Email\n5.Edit Subject\n6.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name :");
                        name = Console.ReadLine();
                        supportEdit.Name = name;
                        validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Name :" + supportEdit.Name);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Phone No:");
                        phone = Console.ReadLine();
                        supportEdit.Phone = phone;
                        validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Phone :" + supportEdit.Phone);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter date of birth");
                        //DateTime.TryParse(Console.ReadLine(), out dob);
                        inputDob();
                        supportEdit.Dob = dob;
                        validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Date of birth :" + supportEdit.Dob);
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                        supportEdit.Email = email;
                        validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Email :" + supportEdit.Email);
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Subject");
                        department = Console.ReadLine();
                        supportEdit.Department = subject;
                        validation(supportEdit);
                        if (valid)
                        {
                            Console.WriteLine("Subject :" + supportEdit.Department);
                        }

                        break;
                    case 6:
                        validation(supportEdit);
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
                            supportList.Remove(support);
                            supportList.Add(supportEdit);
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
           // name = Console.ReadLine();
            //inputId();
            inputName();
            foreach (var support in supportList)
            {
                if (support.Name == name)
                {
                    SupportStaff supportEdit = new SupportStaff();
                    // supportEdit.Id = support.Id;
                    supportEdit.Name = support.Name;
                    supportEdit.Phone = support.Phone;
                    supportEdit.Dob = support.Dob;
                    supportEdit.Email = support.Email;
                    supportEdit.Department = support.Department;
                    EditHelp(support, supportEdit);
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
            // Console.WriteLine("Enter ID :");
            // inputId();
            Console.WriteLine("Enter Name :");
           // name = Console.ReadLine();
           inputName();

            foreach (var support in supportList)
            {
                if (support.Name == name)
                {
                    supportList.Remove(support);
                    Console.WriteLine("Successfully Deleted :\n" +" Name: " + support.Name + " " + "DOB: " + support.Dob + " " + "Phone :" + support.Phone + " " + "Email :" + support.Email + " Subject: " + support.Department);
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found !!");
        }
    }
}