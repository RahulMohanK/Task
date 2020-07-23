using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary
{
    interface StaffOperation
    {
        // public string name ,subject,email,dob,phone,id,designation,department; 
         void EnterValues();
         void AddStaff();
         void RetrieveAllStaff();
         void RetrieveSingleStaff();
         void EditStaff();
         void DeleteStaff();
       
    }
}
