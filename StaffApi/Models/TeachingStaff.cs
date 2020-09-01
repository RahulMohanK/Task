using System;
using System.Collections.Generic;

namespace StaffApi.Models
{
    public partial class TeachingStaff
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Subject { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
