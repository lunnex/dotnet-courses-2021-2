CREATE PROC GetPrizesOfUser(@id int)
AS
SELECT UsersAndPrizes.idUser, Prizes.title
FROM (Prizes JOIN UsersAndPrizes ON Prizes.id = UsersAndPrizes.idPrize)
WHERE UsersAndPrizes.idUser = @id