using System;
using System.Collections.Generic;

namespace StaffApi.Models
{
    public partial class AdministrativeStaff
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Designation { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
