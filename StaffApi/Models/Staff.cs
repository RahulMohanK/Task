using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffApi.Models
{
    public partial class Staff
    {
        public Staff()
        {
            AdministrativeStaff = new HashSet<AdministrativeStaff>();
            SupportingStaff = new HashSet<SupportingStaff>();
            TeachingStaff = new HashSet<TeachingStaff>();

        }
        public enum SType
        {
            AdministrativeStaff,
            TeachingStaff,
            SupportStaff
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "EmpId cannot be null")]
        [RegularExpression("^[a-z0-9]+$", ErrorMessage = "Enter valid Employee Id")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Name must not be null")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Name should not contain special symbols")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = " DateFormat Not Correct")]
        public DateTime? Dob { get; set; }

        [Required(ErrorMessage = "Stafftype cannot be null")]
        public int StaffType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<AdministrativeStaff> AdministrativeStaff { get; set; }
        public virtual ICollection<SupportingStaff> SupportingStaff { get; set; }
        public virtual ICollection<TeachingStaff> TeachingStaff { get; set; }

    }
    public partial class UpdateModelStaff
    {
        public UpdateModelStaff()
        {
            AdministrativeStaff = new HashSet<AdministrativeStaff>();
            SupportingStaff = new HashSet<SupportingStaff>();
            TeachingStaff = new HashSet<TeachingStaff>();

        }
        public int Id { get; set; }

        [Required(ErrorMessage = "EmpId cannot be null")]
        [RegularExpression("^[a-z0-9]+$", ErrorMessage = "Enter valid Employee Id")]
        public string EmpId { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Name should not contain special symbols")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = " DateFormat Not Correct")]
        public DateTime? Dob { get; set; }

        [Required(ErrorMessage = "Stafftype cannot be null")]
        public int StaffType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<AdministrativeStaff> AdministrativeStaff { get; set; }
        public virtual ICollection<SupportingStaff> SupportingStaff { get; set; }
        public virtual ICollection<TeachingStaff> TeachingStaff { get; set; }

    }
}
