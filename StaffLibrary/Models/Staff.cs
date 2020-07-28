using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace StaffLibrary
{

    public abstract class Staff
    {


        private string name;
        private string phone;
        private DateTime dob;
        private string email;



        [Required(ErrorMessage = "Name must not be null")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Name should not contain special symbols")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        [DataType(DataType.DateTime, ErrorMessage = " DateFormat Not Correct")]
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }


    }

}
