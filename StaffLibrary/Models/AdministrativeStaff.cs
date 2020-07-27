using System.ComponentModel.DataAnnotations;
namespace StaffLibrary
{
    public class AdministrativeStaff : Staff
    {
        private string designation;
        [Required(ErrorMessage = "Designation must not be empty")]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Please Enter Valid Designation")]
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
    }

}