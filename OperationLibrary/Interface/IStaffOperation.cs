using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
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
