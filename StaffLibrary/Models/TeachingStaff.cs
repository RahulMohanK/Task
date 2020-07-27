using System.ComponentModel.DataAnnotations;
namespace StaffLibrary
{
    public class TeachingStaff : Staff
    {
        private string subject;

        [Required(ErrorMessage = "Subject must not be empty")]
        [RegularExpression(@"^[a-zA-Z. ]+$", ErrorMessage = "Please Enter Valid Subject")]
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

    }
}