USE [School Database]
GO

/****** Object:  Table [dbo].[AdministrativeStaff]    Script Date: 26-08-2020 13:52:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AdministrativeStaff]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [StaffId] [int] NOT NULL,
    [Designation] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_AdministrativeStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AdministrativeStaff]  WITH CHECK ADD  CONSTRAINT [FK_AdministrativeStaff_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AdministrativeStaff] CHECK CONSTRAINT [FK_AdministrativeStaff_Staff]
GO


