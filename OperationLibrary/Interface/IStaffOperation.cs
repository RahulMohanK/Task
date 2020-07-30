using System;
using System.Collections.Generic;
using StaffLibrary;
using System.ComponentModel;
namespace OperationLibrary

{
    interface IStaffOperation
    {
        [DisplayName("Add Staff")]
        void AddStaff();
        [DisplayName("Retrieve All Staff")]
        void RetrieveAllStaff();
        [DisplayName("Search Staff")]
        void RetrieveSingleStaff();
        [DisplayName("Edit Staff")]
        void EditStaff();
        [DisplayName("Delete Staff")]
        void DeleteStaff();

    }
}
