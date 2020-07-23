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
   
}
