USE [School Database]
GO

/****** Object:  Table [dbo].[SupportingStaff]    Script Date: 26-08-2020 13:53:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SupportingStaff]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [StaffId] [int] NOT NULL,
    [Department] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_SupportingStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SupportingStaff]  WITH CHECK ADD  CONSTRAINT [FK_SupportingStaff_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SupportingStaff] CHECK CONSTRAINT [FK_SupportingStaff_Staff]
GO


