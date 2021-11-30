CREATE PROC [dbo].[DeletePrize](@id int)  
AS  
DELETE FROM UsersAndPrizes  
WHERE idPrize = @id  
DELETE FROM Prizes  
WHERE id = @id