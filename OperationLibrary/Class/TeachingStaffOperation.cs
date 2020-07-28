using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel.DataAnnotations;
namespace OperationLibrary
{

    public class TeachingStaffOperation : StaffOperation, IStaffOperation
    {
        static List<TeachingStaff> teachingList = new List<TeachingStaff>();

        public void AddStaff()
        {
            TeachingStaff teaching = new TeachingStaff();
            do{
            EnterValues();
            Options = configList("Subject");
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

            
            // teaching.Id = id;
            teaching.Name = name;
            teaching.Phone = phone;
            teaching.Dob = dob;
            teaching.Email = email;
            teaching.Subject = subject;
            validation(teaching);
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
                teachingList.Add(teaching);
                    Console.WriteLine("\nValues added are :\n");
                    Console.WriteLine("\nName: " + teaching.Name + " " + "DOB: " + teaching.Dob + " " + "Phone :" + teaching.Phone + " " + "Email :" + teaching.Email + " Subject: " + teaching.Subject); 
            }

            // if (teaching != null)
            // {
            //     ValidationContext context = new ValidationContext(teaching, null, null);
            //     List<ValidationResult> validationResults = new List<ValidationResult>();
            //     valid = Validator.TryValidateObject(teaching, context, validationResults, true);
            //     if (!valid)
            //     {
            //         foreach (ValidationResult validation in validationResults)
            //         {
            //             Console.WriteLine(validation.ErrorMessage);
            //         }
            //     }
            //     else
            //     {
            //         teachingList.Add(teaching);
            //         Console.WriteLine("\nValues added are :\n");
            //         Console.WriteLine("Id :" + teaching.Id + " Name: " + teaching.Name + " " + "DOB: " + teaching.Dob + " " + "Phone :" + teaching.Phone + " " + "Email :" + teaching.Email + " Subject: " + teaching.Subject);
            //     }
            // }
        }

        public void RetrieveAllStaff()
        {
            if (teachingList.Count == 0)
            {
                Console.WriteLine("List is empty\n");
            }
            else
            {
                Console.WriteLine("Details are :\n");
                foreach (var teaching in teachingList)
                {
                    Console.WriteLine("\nName: " + teaching.Name + " " + "DOB: " + teaching.Dob + " " + "Phone :" + teaching.Phone + " " + "Email :" + teaching.Email + " Subject: " + teaching.Subject);
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
            foreach (var teaching in teachingList)
            {
                if ( teaching.Name == name)
                {
                    Console.WriteLine("\nName: " + teaching.Name + " " + "DOB: " + teaching.Dob + " " + "Phone :" + teaching.Phone + " " + "Email :" + teaching.Email + " Subject: " + teaching.Subject);
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found !!");
        }
        public void EditHelp(TeachingStaff teaching, TeachingStaff teachingEdit)
        {
            int option;
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
                        validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Name :" + teachingEdit.Name);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Phone No:");
                        phone = Console.ReadLine();
                        teachingEdit.Phone = phone;
                        validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Phone :" + teachingEdit.Phone);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter date of birth");
                        //DateTime.TryParse(Console.ReadLine(), out dob);
                        inputDob();
                        teachingEdit.Dob = dob;
                        validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Date of birth :" + teaching.Dob);
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter Email");
                        email = Console.ReadLine();
                        teachingEdit.Email = email;
                        validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine(" Email :" + teachingEdit.Email);
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Subject");
                        subject = Console.ReadLine();
                        teachingEdit.Subject = subject;
                        validation(teachingEdit);
                        if (valid)
                        {
                            Console.WriteLine("Subject :" + teachingEdit.Subject);
                        }

                        break;
                    case 6:
                        validation(teachingEdit);
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
                            teachingList.Remove(teaching);
                            teachingList.Add(teachingEdit);
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
            Console.WriteLine("Enter Name:");
            //name = Console.ReadLine();
            // inputId();
            inputName();
            foreach (var teaching in teachingList)
            {
                if (teaching.Name == name)
                {
                    TeachingStaff teachingEdit = new TeachingStaff();
                    // teachingEdit.Id = teaching.Id;
                    teachingEdit.Name = teaching.Name;
                    teachingEdit.Phone = teaching.Phone;
                    teachingEdit.Dob = teaching.Dob;
                    teachingEdit.Email = teaching.Email;
                    teachingEdit.Subject = teaching.Subject;
                    EditHelp(teaching, teachingEdit);
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
            Console.WriteLine("Enter Details of Staff to be Deleted :");
            // Console.WriteLine("Enter ID :");
            // inputId();
            Console.WriteLine("Enter Name :");
            //name = Console.ReadLine();
            inputName();

            foreach (var teaching in teachingList)
            {
                if (teaching.Name == name)
                {
                    teachingList.Remove(teaching);
                    Console.WriteLine("Successfully Deleted :" +"\nName: " + teaching.Name + " " + "DOB: " + teaching.Dob + " " + "Phone :" + teaching.Phone + " " + "Email :" + teaching.Email + " Subject: " + teaching.Subject);
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