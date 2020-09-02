using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StaffApi.Models
{
    public partial class SupportingStaff
    {
        public int Id { get; set; }
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Department must not be empty")]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Please Enter Valid Department")]
        public string Department { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
