USE [School Database]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Staff_updateData]    Script Date: 26-08-2020 13:57:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*update tuple corresponding to StaffType*/
CREATE Procedure [dbo].[Proc_Staff_updateData]
    @EmpId NVARCHAR(50),
    @Name NVARCHAR(50),
    @Phone NVARCHAR(50),
    @Email NVARCHAR(50),
    @Dob DATETIME,
    @StaffType int,
    @Value NVARCHAR(50)
AS
BEGIN
    DECLARE @temp_id int
    IF @StaffType = 0
    BEGIN
        SET @temp_id = (Select S.Id
        from Staff as S INNER join AdministrativeStaff as Ad on S.Id = Ad.StaffId
        where EmpId=@EmpId);
        UPDATE AdministrativeStaff set Designation = @Value where StaffId = @temp_id;
        Update Staff SET
            Name = @Name,
            Phone = @Phone,
            Email= @Email,
            Dob = @Dob ,
            UpdatedDate = GETDATE()
        where EmpId=@EmpId;
    END
    IF @StaffType = 1
    BEGIN
        SET @temp_id = (Select S.Id
        from Staff as S INNER join TeachingStaff as Ad on S.Id = Ad.StaffId
        where EmpId=@EmpId);
        UPDATE TeachingStaff set Subject = @Value where StaffId = @temp_id
        Update Staff SET
            Name = @Name,
            Phone = @Phone,
            Email= @Email,
            Dob = @Dob ,
            UpdatedDate = GETDATE()
        where EmpId=@EmpId;
    END
    IF @StaffType = 2
    BEGIN
        SET @temp_id = (Select S.Id
        from Staff as S INNER join SupportingStaff as Ad on S.Id = Ad.StaffId
        where EmpId=@EmpId)
        UPDATE SupportingStaff set Department = @Value where StaffId = @temp_id;
        Update Staff SET
            Name = @Name,
            Phone = @Phone,
            Email= @Email,
            Dob = @Dob ,
            UpdatedDate = GETDATE()
        where EmpId=@EmpId;
    END


END


GO


