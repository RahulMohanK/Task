USE [School Database]
GO

/****** Object:  Table [dbo].[Staff]    Script Date: 26-08-2020 13:51:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Staff]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [EmpId] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Phone] [nvarchar](50) NULL,
    [Email] [nvarchar](50) NULL,
    [Dob] [datetime] NULL,
    [StaffType] [int] NOT NULL,
    [CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Staff_CreatedDate]  DEFAULT (getdate()),
    [UpdatedDate] [datetime] NOT NULL CONSTRAINT [DF_Staff_UpdatedDate]  DEFAULT (getdate()),
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
