using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffApi.Models;
using DbOperationLibrary;
using System.Data;
using System.Data.SqlClient;
namespace StaffApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private StaffApiContext context;


        public StaffController(StaffApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Staff> GetStaffs()
        {
            List<Staff> finalResult = new List<Staff>();
            foreach (var item in context.Staff.ToList())
            {
                var result = item;
                if (result.StaffType == 0)
                {
                    result.AdministrativeStaff.Add(context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == result.Id));
                }
                else if (result.StaffType == 1)
                {
                    result.TeachingStaff.Add(context.TeachingStaff.FirstOrDefault(e => e.StaffId == result.Id));
                }
                else
                {
                    result.SupportingStaff.Add(context.SupportingStaff.FirstOrDefault(e => e.StaffId == result.Id));
                }
                finalResult.Add(result);
            }
            return finalResult;
        }

        [HttpGet("{empId}")]
        public ActionResult<Staff> GetStaff(string empId)
        {

            var result = context.Staff.FirstOrDefault(e => e.EmpId == empId);
            if (result == null)
            {
                return NotFound();
            }
            if (result.StaffType == 0)
            {
                result.AdministrativeStaff.Add(context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == result.Id));
            }
            else if (result.StaffType == 1)
            {
                result.TeachingStaff.Add(context.TeachingStaff.FirstOrDefault(e => e.StaffId == result.Id));
            }
            else
            {
                result.SupportingStaff.Add(context.SupportingStaff.FirstOrDefault(e => e.StaffId == result.Id));
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(DummyStaff dstaff)
        {
            Staff staff = new Staff();
            staff.EmpId = dstaff.EmpId;
            staff.Name = dstaff.Name;
            staff.Phone = dstaff.Phone;
            staff.Email = dstaff.Email;
            staff.Dob = dstaff.Dob;
            staff.StaffType = dstaff.StaffType;
            context.Staff.Add(staff);
            if (dstaff.StaffType == 0)
            {
                AdministrativeStaff admin = new AdministrativeStaff();
                admin.Designation = dstaff.Value;
                staff.AdministrativeStaff.Add(admin);
            }
            else if (dstaff.StaffType == 1)
            {
                TeachingStaff teaching = new TeachingStaff();
                teaching.Subject = dstaff.Value;
                staff.TeachingStaff.Add(teaching);
            }
            else
            {
                SupportingStaff support = new SupportingStaff();
                support.Department = dstaff.Value;
                staff.SupportingStaff.Add(support);
            }
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStaffs", new { id = staff.Id }, staff);
        }
        [HttpDelete("{empId}")]
        public async Task<ActionResult<Staff>> DeleteStaff(string empId)
        {
            var staff = context.Staff.FirstOrDefault(e => e.EmpId == empId);
            if (staff == null)
            {
                return NotFound();
            }
            if (staff.StaffType == 0)
            {
                var admin = context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == staff.Id);
                context.AdministrativeStaff.Remove(admin);
            }
            else if (staff.StaffType == 1)
            {
                var teaching = context.TeachingStaff.FirstOrDefault(e => e.StaffId == staff.Id);
                context.TeachingStaff.Remove(teaching);
            }
            else
            {
                var support = context.SupportingStaff.FirstOrDefault(e => e.StaffId == staff.Id);
                context.SupportingStaff.Remove(support);
            }
            context.Staff.Remove(staff);
            await context.SaveChangesAsync();

            return staff;
        }






    }

}
