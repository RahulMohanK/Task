using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary
{
    public abstract class StaffOperation
    {
        
        public abstract void AddStaff();
        public abstract void RetrieveAllStaff();
        public abstract void RetrieveSingleStaff();
        public abstract void EditStaff();
        public abstract void DeleteStaff();
    }

    public class TeachingStaffOperation: StaffOperation
    {
        static List<TeachingStaff> teachingList = new List<TeachingStaff>();
        public override void AddStaff()
        {
            string name ,subject,email,dob,phone,id; 
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

            Console.WriteLine("Enter Subject");
            subject = Console.ReadLine();

            TeachingStaff teaching = new TeachingStaff(Convert.ToInt32(id),name,long.Parse(phone),dob,email,subject);
            
            if(teaching!=null)
            {
            teachingList.Add(teaching);
            Console.WriteLine("Values added are :\n");
                // return teachingList;
           
            Console.WriteLine("Id :"+teaching.id+"Name: "+teaching.Name+" "+"DOB: "+teaching.dob+" "+"Phone :"+teaching.phone+" "+"Email :"+teaching.email+"Subject: "+teaching.Subject);
            
            }
        }

        public override void RetrieveAllStaff()
        {
           
           if(teachingList.Count ==0)
           {
               Console.WriteLine("List is empty\n");
           }
           else
           {
            Console.WriteLine("Details are :\n");
            foreach(var teaching in teachingList)
            {
                Console.WriteLine("Id :"+teaching.id+"Name: "+teaching.Name+" "+"DOB: "+teaching.dob+" "+"Phone :"+teaching.phone+" "+"Email :"+teaching.email+"Subject: "+teaching.Subject);
            }
           }
           
            
           
        }
        public override void RetrieveSingleStaff()
        {

        }
        public override void EditStaff()
        {

        }
        public override void DeleteStaff()
        {

        }

    }
    public class AdministrativeStaffOperation : StaffOperation
    {
        static List<AdministrativeStaff> administrativeList = new List<AdministrativeStaff>();
        public override void AddStaff()
        {
            string name ,designation,email,dob,phone,id; 
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
            AdministrativeStaff admin = new AdministrativeStaff(Convert.ToInt32(id),name,long.Parse(phone),dob,email,designation);
            
            if(admin!=null)
            {
            administrativeList.Add(admin);
            Console.WriteLine("Values added are :\n");
                // return teachingList;
            Console.WriteLine("Id :"+admin.id+"Name: "+admin.Name+" "+"DOB: "+admin.dob+" "+"Phone :"+admin.phone+" "+"Email :"+admin.email+"Designation: "+admin.designation);
            
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
                 Console.WriteLine("\nId :"+admin.id+" Name: "+admin.Name+" "+"DOB: "+admin.dob+" "+"Phone :"+admin.phone+" "+"Email :"+admin.email+" Designation: "+admin.designation);
            }
           }
            
        }
        public override void RetrieveSingleStaff()
        {

        }
        public override void EditStaff()
        {

        }
        public override void DeleteStaff()
        {
            
        }
    }
    public class SupportStaffOperation : StaffOperation
    {
        static List<SupportStaff> supportList = new List<SupportStaff>();
         public override void AddStaff()
        {
            string name ,department,email,dob,phone,id; 
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
            SupportStaff support= new SupportStaff(Convert.ToInt32(id),name,long.Parse(phone),dob,email,department);
           
             if(support!=null)
            {
            supportList.Add(support);
            Console.WriteLine("Values added are :\n");
                // return teachingList;
            Console.WriteLine("Id :"+support.id+ "Name: "+support.Name+" "+"DOB: "+support.dob+" "+"Phone :"+support.phone+" "+"Email :"+support.email+" Department: "+support.department);
            
            }
        }
         public override void RetrieveAllStaff()
        {
            if(supportList.Count ==0)
           {
               Console.WriteLine("List is empty\n");
           }
            else{
             Console.WriteLine("Details are :\n");
             foreach(var support in supportList)
            {
               Console.WriteLine("\nId :"+support.id+"Name: "+support.Name+" "+"DOB: "+support.dob+" "+"Phone :"+support.phone+" "+"Email :"+support.email+"Department: "+support.department);
            }
            }
        }
        public override void RetrieveSingleStaff()
        {

        }
        public override void EditStaff()
        {

        }
        public override void DeleteStaff()
        {
            
        }
    }
}
