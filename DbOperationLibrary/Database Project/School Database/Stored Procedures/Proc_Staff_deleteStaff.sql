USE [School Database]
GO

/****** Object:  StoredProcedure [dbo].[proc_deleteStaff]    Script Date: 26-08-2020 13:21:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* delete staff based on employee id and stafftype*/
CREATE Procedure [dbo].[Proc_Staff_deleteStaff]
    @StaffType int,
    @EmpId VARCHAR(50)
AS
BEGIN
    DECLARE @temp_id int
    IF @StaffType = 0
    BEGIN
        SET @temp_id = (Select S.Id
        from Staff as S INNER join AdministrativeStaff as Ad on S.Id = Ad.StaffId
        where EmpId=@EmpId);
        Delete from Staff WHERE Id = @temp_id;
    END
    IF @StaffType = 1
    BEGIN
        SET @temp_id = (Select S.Id
        from Staff as S INNER join TeachingStaff as Ad on S.Id = Ad.StaffId
        where EmpId=@EmpId);
        Delete from Staff WHERE Id = @temp_id;
    END
    IF @StaffType = 2
    BEGIN
        SET @temp_id = (Select S.Id
        from Staff as S INNER join SupportingStaff as Ad on S.Id = Ad.StaffId
        where EmpId=@EmpId);
        Delete from Staff WHERE Id = @temp_id;
    END

END

GO


