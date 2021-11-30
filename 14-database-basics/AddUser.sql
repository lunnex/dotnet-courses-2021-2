CREATE PROC [dbo].[AddUser] (@firstName nvarchar(50),  
      @lastName nvarchar(50),  
      @birthday date)  
AS  
DECLARE @age int;  
SET @age = YEAR(GETDATE()) - YEAR(@birthday)  
IF (MONTH(GETDATE()) > MONTH(@birthday)) OR (MONTH(GETDATE()) = MONTH(@birthday) AND DAY(GETDATE()) > DAY(@birthday))  
BEGIN  
SET @age = @age + 1;  
END;  
IF @age < 150  
begin  
INSERT INTO Users (firstName, lastName, birthday)  
values(@firstName, @lastName, @birthday);  
END;  
ELSE PRINT 'ERROR'