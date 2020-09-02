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
using DbOperationLibrary;

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
            // DatabaseOperation databaseOperation = new DatabaseOperation();
            // finalResult = databaseOperation.Retrive();
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
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            if ((staff.StaffType == (int)Staff.SType.AdministrativeStaff && staff.AdministrativeStaff.Count == 1)
                || (staff.StaffType == (int)Staff.SType.TeachingStaff && staff.TeachingStaff.Count == 1)
                || (staff.StaffType == (int)Staff.SType.SupportStaff && staff.SupportingStaff.Count == 1))
            {
                context.Staff.Add(staff);
            }
            else
            {
                return BadRequest();
            }
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStaffs", new { id = staff.Id }, staff);
        }

        [HttpDelete("{empId}")]
        public async Task<ActionResult<Staff>> DeleteStaff(string empId)
        {
            var staff = context.Staff.FirstOrDefault(e => e.EmpId == empId);
            DatabaseOperation databaseOperation = new DatabaseOperation();
            if (staff == null)
            {
                return NotFound();
            }
            databaseOperation.DeleteStaff(staff.StaffType, empId);

            return staff;
        }

        [HttpPut("{empId}")]
        public ActionResult<Staff> PutStaff(string empId, Staff dstaff)
        {

            if (empId != dstaff.EmpId)
            {
                return BadRequest();
            }
            if (!StaffExists(empId))
            {
                return NotFound();
            }
            string value;
            DatabaseOperation databaseOperation = new DatabaseOperation();
            var result = context.Staff.FirstOrDefault(e => e.EmpId == dstaff.EmpId);
            Staff staff = new Staff();
            staff.EmpId = result.EmpId;
            staff.Name = result.Name;
            staff.Phone = result.Phone;
            staff.Email = result.Email;
            staff.StaffType = result.StaffType;
            staff.Dob = result.Dob;
            if (result.StaffType == (int)Staff.SType.AdministrativeStaff)
            {
                var admin = context.AdministrativeStaff.FirstOrDefault(e => e.StaffId == result.Id);
                value = admin.Designation;
            }
            else if (result.StaffType == (int)Staff.SType.TeachingStaff)
            {
                var teaching = context.TeachingStaff.FirstOrDefault(e => e.StaffId == result.Id);
                value = teaching.Subject;
            }
            else
            {
                var support = context.SupportingStaff.FirstOrDefault(e => e.StaffId == result.Id);
                value = support.Department;
            }

            if (!String.IsNullOrEmpty(dstaff.Name))
            {
                staff.Name = dstaff.Name;
            }
            if (!String.IsNullOrEmpty(dstaff.Phone))
            {
                staff.Phone = dstaff.Phone;
            }
            if (!String.IsNullOrEmpty(dstaff.Email))
            {
                staff.Email = dstaff.Email;
            }
            if (dstaff.Dob != null)
            {
                staff.Dob = dstaff.Dob;
            }
            if (staff.StaffType == (int)Staff.SType.AdministrativeStaff && dstaff.AdministrativeStaff.Count == 1)
            {
                value = dstaff.AdministrativeStaff.ElementAt(0).Designation;

            }
            if (dstaff.StaffType == (int)Staff.SType.TeachingStaff && dstaff.TeachingStaff.Count == 1)
            {
                value = dstaff.TeachingStaff.ElementAt(0).Subject;

            }
            if (dstaff.StaffType == (int)Staff.SType.SupportStaff && dstaff.SupportingStaff.Count == 1)
            {
                value = dstaff.SupportingStaff.ElementAt(0).Department;

            }

            databaseOperation.UpdateStaff(empId, staff.Name, staff.Phone, staff.Email, Convert.ToDateTime(staff.Dob), staff.StaffType, value);

            return staff;
        }

        private bool StaffExists(string empId)
        {
            return context.Staff.Any(e => e.EmpId == empId);
        }




    }

}
