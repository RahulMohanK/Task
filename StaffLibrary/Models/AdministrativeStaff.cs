using System.ComponentModel.DataAnnotations;
namespace StaffLibrary
{
     public class AdministrativeStaff : Staff
    {
        public string designation;
        
    //    public AdministrativeStaff(int id,string name,long phone,string dob,string email, string designation)
    //    {
    //         this.id = id;
    //         this.name = name;
    //         this.phone = phone;
    //         this.dob = dob;
    //         this.email = email;
    //         this.designation = designation;
    //    }
        [Required(ErrorMessage="Designation must not be empty")]
        [RegularExpression("^[a-zA-Z. ]+$",ErrorMessage="Please Enter Valid Designation")]
       public string Designation
        {
            get{return designation;}
            set{designation = value;}
        }
    }

}