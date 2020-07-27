using System;
using System.Collections.Generic;
using StaffLibrary;
namespace OperationLibrary

{
    interface IStaffOperation
    {
        void AddStaff();
        void RetrieveAllStaff();
        void RetrieveSingleStaff();
        void EditStaff();
        void DeleteStaff();

    }
}
