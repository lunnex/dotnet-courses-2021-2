CREATE PROC DeleteUser(@id int)  
AS  
DELETE FROM UsersAndPrizes WHERE idUser = @id;  
DELETE FROM Users WHERE id = @id;