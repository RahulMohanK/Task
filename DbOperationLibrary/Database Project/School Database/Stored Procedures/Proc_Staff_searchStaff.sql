USE [School Database]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Staff_searchStaff]    Script Date: 26-08-2020 13:57:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* search staff based on name and stafftype*/
CREATE Procedure [dbo].[Proc_Staff_searchStaff]
    @StaffType int,
    @Name NVARCHAR(50)
AS
BEGIN
    DECLARE @pattern nvarchar(50)
    set @pattern = @Name + '%'
    ;
    SELECT S.EmpId, S.Name, S.Phone, S.Email, S.Dob, Ad.Designation, T.Subject, Su.Department, S.StaffType, dbo.FN_getAge(S.Dob) Age
    FROM Staff as S
        Left JOIN AdministrativeStaff as Ad ON S.Id = Ad.StaffId
        Left join TeachingStaff as T on S.Id = T.StaffId
        left join SupportingStaff as Su on S.Id = Su.StaffId
    where StaffType = @StaffType and Name Like @pattern;

END


GO


