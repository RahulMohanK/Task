namespace StaffLibrary{
 public class SupportStaff : Staff
    {
       public string department;
      

    //    public SupportStaff(int id,string name,long phone,string dob,string email, string department)
    //    {
    //         this.id = id;
    //         this.name = name;
    //         this.phone = phone;
    //         this.dob = dob;
    //         this.email = email;
    //         this.department = department;
    //    }
        public string Department 
       {
           get{ return department;}
           set{ department = value;}
       }
    }
}