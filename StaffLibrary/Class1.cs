using System;

namespace StaffLibrary
{
    public class Staff
    {
        public int id;
        public string name;
        public long phone;
        public string dob;
        public string email;
        public int Id{
            get{return id;}
            set{id = value;}
        }
        public string Name
        {
            get{return name;}
            set {name = value;}
        }
        public long Phone{
            get{return phone;}
            set{phone = value;}
        }
        public string Dob
        {
            get{return dob; }
            set{dob = value;}
        }
        public string Email
        {
            get{return email;}
            set{email = value;}
        }
    }
     public class TeachingStaff : Staff
    {
        public string subject;
        public TeachingStaff(int id,string name,long phone,string dob,string email, string subject)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.dob = dob;
            this.email = email;
            this.subject = subject;
        }
        public string Subject 
        {
            get{return subject;}
            set{subject = value;}
        }
       
    }

    public class AdministrativeStaff : Staff
    {
        public string designation;
        
       public AdministrativeStaff(int id,string name,long phone,string dob,string email, string designation)
       {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.dob = dob;
            this.email = email;
            this.designation = designation;
       }
       public string Designation
        {
            get{return designation;}
            set{designation = value;}
        }
    }

     public class SupportStaff : Staff
    {
       public string department;
      

       public SupportStaff(int id,string name,long phone,string dob,string email, string department)
       {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.dob = dob;
            this.email = email;
            this.department = department;
       }
        public string Department 
       {
           get{ return department;}
           set{ department = value;}
       }
    }
   
}
