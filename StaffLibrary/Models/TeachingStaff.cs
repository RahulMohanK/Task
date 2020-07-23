namespace StaffLibrary
{
      public class TeachingStaff : Staff
    {
        public string subject;
        // public TeachingStaff(int id,string name,long phone,string dob,string email, string subject)
        // {
        //     this.id = id;
        //     this.name = name;
        //     this.phone = phone;
        //     this.dob = dob;
        //     this.email = email;
        //     this.subject = subject;
        // }
               public string Subject 
        {
            get{return subject;}
            set{subject = value;}
        }
       
    }
}