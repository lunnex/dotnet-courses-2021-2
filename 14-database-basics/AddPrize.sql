CREATE PROC AddPrize(@title nvarchar(50), 
						@description nvarchar(250) null)
AS
INSERT INTO Prizes (title, description)
values(@title, @description)

EXEC addPrize 'Золотая малина', null