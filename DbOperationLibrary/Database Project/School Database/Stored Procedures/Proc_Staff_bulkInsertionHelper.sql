create procedure [dbo].[Proc_Staff_bulkInsertionHelper]
    @typetable typ_Staff Readonly
as
begin

    insert into Staff
        (EmpId,Name,Phone,Email,Dob,StaffType,CreatedDate,UpdatedDate)
    select EmpId, Name, Phone, Email, Dob, StaffType, CreatedDate, UpdatedDate
    from @typetable


    insert into AdministrativeStaff
        (StaffId,Designation)
    select S.Id, T.Value
    from Staff as S inner join @typetable as T on S.EmpId = T.EmpId and T.StaffType = 0;

    insert into TeachingStaff
        (StaffId,Subject)
    select S.Id, T.Value
    from Staff as S inner join @typetable as T on S.EmpId = T.EmpId and T.StaffType =1;

    insert into SupportingStaff
        (StaffId,Department)
    select S.Id, T.Value
    from Staff as S inner join @typetable as T on S.EmpId = T.EmpId and T.StaffType = 2;


end