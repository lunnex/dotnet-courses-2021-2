CREATE PROC EditPrize(@id int, @title nvarchar(50), 
						@description nvarchar(250) null)
AS
UPDATE Prizes
SET title = @title, description = @description 
WHERE id = @id