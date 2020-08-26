USE [School Database]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Staff_retireveAll]    Script Date: 26-08-2020 13:56:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* retrieve all rows from table */
CREATE Procedure [dbo].[Proc_Staff_retireveAll]
    @StaffType int
AS
BEGIN

    SELECT S.EmpId, S.Name, S.Phone, S.Email, S.Dob, Ad.Designation, T.Subject, Su.Department, dbo.FN_getAge(S.Dob) Age
    FROM Staff as S
        Left JOIN AdministrativeStaff as Ad ON S.Id = Ad.StaffId
        Left join TeachingStaff as T on S.Id = T.StaffId
        left join SupportingStaff as Su on S.Id = Su.StaffId
    where StaffType = @StaffType;


END


GO


