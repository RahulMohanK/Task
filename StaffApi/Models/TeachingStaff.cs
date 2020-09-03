using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StaffApi.Models
{
    public partial class TeachingStaff
    {
        public int Id { get; set; }
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Subject must not be empty")]
        [RegularExpression(@"^[a-zA-Z. ]+$", ErrorMessage = "Please Enter Valid Subject")]

        public string Subject { get; set; }

        public virtual Staff Staff { get; set; }
    }

}
