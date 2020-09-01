using System;
using System.Collections.Generic;

namespace StaffApi.Models
{
    public partial class SupportingStaff
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Department { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
