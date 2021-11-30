CREATE PROC AddPrizeToUser(@idUser int, @idPrize int)
AS
INSERT INTO UsersAndPrizes 
VALUES(@idUser, @idPrize)