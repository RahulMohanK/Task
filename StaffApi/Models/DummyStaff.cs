using System;
namespace StaffApi.Models
{
    public class DummyStaff
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public int StaffType { get; set; }
        public string Value { get; set; }
    }
}