CREATE PROC [dbo].[EditUser] (@id int,  
      @firstName nvarchar(50),  
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
BEGIN  
UPDATE Users  
SET firstName = @firstName, lastName = @lastName, birthday = @birthday  
WHERE id = @id  
END  
ELSE PRINT 'ERROR'