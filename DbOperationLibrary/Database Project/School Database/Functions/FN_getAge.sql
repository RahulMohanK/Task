USE [School Database]
GO

/****** Object:  UserDefinedFunction [dbo].[FN_getAge]    Script Date: 26-08-2020 14:03:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create function [dbo].[FN_getAge](
@Dob datetime
)
returns int
as
begin
    declare @age int
    set @age =
	 (select (0 + Convert(Char(8),GETDATE(),112) - Convert(Char(8),@Dob,112)) / 10000);
    return @age;

end

GO


