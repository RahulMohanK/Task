USE [School Database]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Staff_retireveSingleStaff]    Script Date: 26-08-2020 13:56:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* retrieve single staff based on stafftype and employee id*/
Create Procedure [dbo].[Proc_Staff_retireveSingleStaff]
    @StaffType int,
    @EmpId NVARCHAR(50)
AS
BEGIN
    SELECT S.EmpId, S.Name, S.Phone, S.Email, S.Dob, Ad.Designation, T.Subject, Su.Department
    FROM Staff as S
        Left JOIN AdministrativeStaff as Ad ON S.Id = Ad.StaffId
        Left join TeachingStaff as T on S.Id = T.StaffId
        left join SupportingStaff as Su on S.Id = Su.StaffId
    where StaffType = @StaffType and EmpId = @EmpId;

END



GO


