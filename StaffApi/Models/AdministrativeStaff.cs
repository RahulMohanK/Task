using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StaffApi.Models
{
    public partial class AdministrativeStaff
    {
        public int Id { get; set; }
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Designation must not be empty")]
        [RegularExpression("^[a-zA-Z. ]+$", ErrorMessage = "Please Enter Valid Designation")]
        public string Designation { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
