﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StaffLibrary
{
    public class Staff
    {

        private int id;
        private string name;
        private string phone;
        private string dob;
        private string email;

        [Required(ErrorMessage = "Id must not be null")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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

        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{1,2}/\d{1,2}/\d{4}$", ErrorMessage = "Dateformat not correct")]
        public string Dob
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
