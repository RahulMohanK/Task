using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary
{
    public abstract class StaffOperation
    {
        public string name ,subject,email,dob,phone,id,designation,department; 
        public abstract void EnterValues();
        public abstract void AddStaff();
        public abstract void RetrieveAllStaff();
        public abstract void RetrieveSingleStaff();
        public abstract void EditStaff();
        public abstract void DeleteStaff();
       
    }
}
