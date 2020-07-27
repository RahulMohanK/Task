using System.ComponentModel.DataAnnotations;
namespace StaffLibrary
{
    public class SupportStaff : Staff
    {
        private string department;

        [Required(ErrorMessage = "Department must not be empty")]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Please Enter Valid Department")]
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
    }
}