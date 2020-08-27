CREATE TYPE [dbo].[typ_Staff] AS TABLE(
    [EmpId] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Phone] [nvarchar](50) NULL,
    [Email] [nvarchar](50) NULL,
    [Dob] [datetime] NULL,
    [StaffType] [int] NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
    [UpdatedDate] [datetime] NOT NULL DEFAULT (getdate()),
    [Value] [nvarchar](50) NOT NULL
)