using System;
using System.Collections.Generic;

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

        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public int StaffType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<AdministrativeStaff> AdministrativeStaff { get; set; }
        public virtual ICollection<SupportingStaff> SupportingStaff { get; set; }
        public virtual ICollection<TeachingStaff> TeachingStaff { get; set; }

    }
}
