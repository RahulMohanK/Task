using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary

{
    interface IStaffOperation
    {
         void EnterValues();
         void AddStaff();
         void RetrieveAllStaff();
         void RetrieveSingleStaff();
         void EditStaff();
         void DeleteStaff();
       
    }
}
