USE [School Database]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Staff_addData]    Script Date: 26-08-2020 13:54:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* add data to table*/
Create Procedure [dbo].[Proc_Staff_addData]
    @EmpId NVARCHAR(50),
    @Name NVARCHAR(50),
    @Phone NVARCHAR(50),
    @Email NVARCHAR(50),
    @Dob DATETIME,
    @StaffType int,
    @Value NVARCHAR(50)
AS
BEGIN
    IF @StaffType = 0
    BEGIN
        INSERT into Staff
            (EmpId,Name,Phone,Email,Dob,StaffType,CreatedDate,UpdatedDate)
        values
            (@EmpId, @Name, @Phone, @Email, @Dob, @StaffType, GETDATE(), GETDATE())
        INSERT into AdministrativeStaff
            (StaffId,Designation)
        values((Select Id
                from Staff
                where EmpId = @EmpId), @Value)
    END
    IF @StaffType = 1
    BEGIN
        INSERT into Staff
            (EmpId,Name,Phone,Email,Dob,StaffType,CreatedDate,UpdatedDate)
        values
            (@EmpId, @Name, @Phone, @Email, @Dob, @StaffType, GETDATE(), GETDATE())
        INSERT into TeachingStaff
            (StaffId,Subject)
        values((Select Id
                from Staff
                where EmpId = @EmpId), @Value)
    END
    IF @StaffType = 2
    BEGIN
        INSERT into Staff
            (EmpId,Name,Phone,Email,Dob,StaffType,CreatedDate,UpdatedDate)
        values
            (@EmpId, @Name, @Phone, @Email, @Dob, @StaffType, GETDATE(), GETDATE())
        INSERT into SupportingStaff
            (StaffId,Department)
        values((Select Id
                from Staff
                where EmpId = @EmpId), @Value)
    END


END


GO


