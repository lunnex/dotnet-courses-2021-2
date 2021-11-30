CREATE TABLE Users(id int primary key identity(1,1), firstName nvarchar(50) NOT NULL, lastName nvarchar(50) NOT NULL, birthday DATE NOT NULL CHECK (birthday < GETDATE()), age INT CHECK (age < 150))

CREATE TABLE Prizes (id int primary key identity(1,1), title nvarchar(50) NOT NULL, description nvarchar(250) NULL)

CREATE TABLE UsersAndPrizes(idUser int references Users(id), idPrize int references Prizes(id), primary key(idUser, idPrize))