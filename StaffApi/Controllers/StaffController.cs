using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffApi.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;

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
            List<Staff> finalResult = new List<StaffApi.Models.Staff>();
            foreach (var item in context.Staff.ToList())
            {
                var result = item;
                if (result.StaffType == (int)Staff.SType.AdministrativeStaff)
                {
                    result.AdministrativeStaff.Add(context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == result.Id));
                }
                else if (result.StaffType == (int)Staff.SType.TeachingStaff)
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
            if (result.StaffType == (int)Staff.SType.AdministrativeStaff)
            {
                result.AdministrativeStaff.Add(context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == result.Id));
            }
            else if (result.StaffType == (int)Staff.SType.TeachingStaff)
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
            if (dstaff.StaffType == (int)Staff.SType.AdministrativeStaff)
            {
                AdministrativeStaff admin = new AdministrativeStaff();
                admin.Designation = dstaff.Value;
                staff.AdministrativeStaff.Add(admin);
            }
            else if (dstaff.StaffType == (int)Staff.SType.TeachingStaff)
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
            if (staff.StaffType == (int)Staff.SType.AdministrativeStaff)
            {
                var admin = context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == staff.Id);
                context.AdministrativeStaff.Remove(admin);
            }
            else if (staff.StaffType == (int)Staff.SType.TeachingStaff)
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

        [HttpPut("{empId}")]
        public async Task<ActionResult<Staff>> PutStaff(string empId, DummyStaff dstaff)
        {

            if (empId != dstaff.EmpId)
            {
                return BadRequest();
            }
            if (!StaffExists(empId))
            {
                return NotFound();
            }

            var result = context.Staff.FirstOrDefault(e => e.EmpId == dstaff.EmpId);
            Staff staff = new Staff();
            staff.EmpId = result.EmpId;
            staff.Name = result.Name;
            staff.Phone = result.Phone;
            staff.Email = result.Email;
            staff.StaffType = result.StaffType;
            staff.Dob = result.Dob;
            staff.CreatedDate = result.CreatedDate;
            staff.UpdatedDate = result.UpdatedDate;

            var deleteStaff = context.Staff.FirstOrDefault(e => e.EmpId == empId);
            if (deleteStaff.StaffType == (int)Staff.SType.AdministrativeStaff)
            {
                var admin = context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == deleteStaff.Id);
                context.AdministrativeStaff.Remove(admin);
            }
            else if (deleteStaff.StaffType == (int)Staff.SType.TeachingStaff)
            {
                var teaching = context.TeachingStaff.FirstOrDefault(e => e.StaffId == deleteStaff.Id);
                context.TeachingStaff.Remove(teaching);
            }
            else
            {
                var support = context.SupportingStaff.FirstOrDefault(e => e.StaffId == deleteStaff.Id);
                context.SupportingStaff.Remove(support);
            }
            context.Staff.Remove(deleteStaff);
            await context.SaveChangesAsync();
            staff.Name = dstaff.Name;
            staff.Phone = dstaff.Phone;
            staff.Email = dstaff.Email;
            staff.Dob = dstaff.Dob;
            staff.UpdatedDate = Convert.ToDateTime(DateTime.Now);
            context.Staff.Add(staff);
            if (dstaff.StaffType == (int)Staff.SType.AdministrativeStaff)
            {
                AdministrativeStaff admin = new AdministrativeStaff();
                admin.Designation = dstaff.Value;
                staff.AdministrativeStaff.Add(admin);
            }
            else if (dstaff.StaffType == (int)Staff.SType.TeachingStaff)
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
            return staff;
        }

        private bool StaffExists(string empId)
        {
            return context.Staff.Any(e => e.EmpId == empId);
        }




    }

}
