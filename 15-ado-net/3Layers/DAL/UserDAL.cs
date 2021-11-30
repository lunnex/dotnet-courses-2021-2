using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DALDB
{
    public class UserDAL : IUserDAO
    {
        private readonly string _connectoinString;

        public UserDAL(string connectionString)
        {
            _connectoinString = connectionString;
        }

        public List<User> GetAll()
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT* FROM UsersWithAges";
                connection.Open();

                var reader = command.ExecuteReader();
                

                List<int> id = new List<int>();
                List<string> firstName = new List<string>();
                List<string> lastName = new List<string>();
                List<string> date = new List<string>();
                while (reader.Read())
                {
                    id.Add(reader.GetInt32(0));
                    firstName.Add(reader.GetString(1));
                    lastName.Add(reader.GetString(2));
                    date.Add(reader.GetDateTime(3).ToString());
                    
                }
                reader.Close();

                

                for (int i = 0; i < id.Count; i++)
                {
                    var listOfPrizes = new List<Prize>();
                    var commandGetListOfPrizes = connection.CreateCommand();
                    //commandGetListOfPrizes.CommandText = $"EXEC GetPrizesOfUser '{id[i]}'";
                    commandGetListOfPrizes.CommandText = "GetPrizesOfUser";
                    commandGetListOfPrizes.CommandType = System.Data.CommandType.StoredProcedure;
                    commandGetListOfPrizes.Parameters.Add("id", System.Data.SqlDbType.Int).Value = id[i];
                    var readerOfPrizesOfUser = commandGetListOfPrizes.ExecuteReader();
                    while (readerOfPrizesOfUser.Read())
                    {
                        var prize = new Prize(readerOfPrizesOfUser.GetInt32(0), readerOfPrizesOfUser.GetString(1), readerOfPrizesOfUser.GetString(2));
                        listOfPrizes.Add(prize);
                    }
                    readerOfPrizesOfUser.Close();
                    User user = new User(id[i], firstName[i], lastName[i], date[i], listOfPrizes);
                    users.Add(user);
                }
            }
            return users;
        }

        public void Add(User user)
        {
            var prizeDAL = new PrizeDAL(_connectoinString);
            int idOfUser;
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                //command.CommandText = $"EXEC AddUser '{user.FirstName}', '{user.LastName}', '{user.DateOfBirth}'";
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("firstName", System.Data.SqlDbType.NVarChar).Value = user.FirstName;
                command.Parameters.Add("lastName", System.Data.SqlDbType.NVarChar).Value = user.LastName;
                command.Parameters.Add("birthday", System.Data.SqlDbType.DateTime).Value = user.DateOfBirth;
                connection.Open();
                command.ExecuteNonQuery();

                var getIdOfUser = connection.CreateCommand();
                getIdOfUser.CommandText = $"SELECT MAX(id) FROM Users";
                idOfUser = (int) getIdOfUser.ExecuteScalar();
                connection.Close();


            }

            var listOfPrizes = prizeDAL.GetAll();
            using (var connectionAddPrizes = new SqlConnection(_connectoinString))
            {
                for (int i = 0; i < user.ListOfPrize.Count; i++)
                {
                    var addPrizeCommand = connectionAddPrizes.CreateCommand();
                    //addPrizeCommand.CommandText = $"EXEC AddPrizeToUser '{idOfUser}', '{user.ListOfPrize[i].ID}'";
                    addPrizeCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    addPrizeCommand.CommandText = "AddPrizeToUser";
                    addPrizeCommand.Parameters.Add("idUser", System.Data.SqlDbType.Int).Value = idOfUser;
                    addPrizeCommand.Parameters.Add("idPrize", System.Data.SqlDbType.Int).Value = user.ListOfPrize[i].ID;
                    connectionAddPrizes.Open();
                    addPrizeCommand.ExecuteNonQuery();
                    connectionAddPrizes.Close();
                }
            }
        }

        public void Edit(User oldUser, User newUser)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "EditUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("id", System.Data.SqlDbType.Int).Value = oldUser.ID;
                command.Parameters.Add("firstName", System.Data.SqlDbType.NVarChar).Value = newUser.FirstName;
                command.Parameters.Add("lastName", System.Data.SqlDbType.NVarChar).Value = newUser.LastName;
                command.Parameters.Add("birthday", System.Data.SqlDbType.DateTime).Value = newUser.DateOfBirth;


                var commandDeletePrizesOfUser = connection.CreateCommand();
                commandDeletePrizesOfUser.CommandText = "DeletePrizesOfUser";
                commandDeletePrizesOfUser.CommandType = System.Data.CommandType.StoredProcedure;
                commandDeletePrizesOfUser.Parameters.Add("idUser", System.Data.SqlDbType.Int).Value = oldUser.ID;


                connection.Open();
                command.ExecuteNonQuery();
                commandDeletePrizesOfUser.ExecuteNonQuery();

                for (int i = 0; i < newUser.ListOfPrize.Count; i++)
                {
                    var addPrizeCommand = connection.CreateCommand();
                    addPrizeCommand.CommandText = "AddPrizeToUser";
                    addPrizeCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    addPrizeCommand.Parameters.Add("idUser", System.Data.SqlDbType.Int).Value = oldUser.ID;
                    addPrizeCommand.Parameters.Add("idPrize", System.Data.SqlDbType.Int).Value = newUser.ListOfPrize[i].ID;
                    //connection.Open();
                    addPrizeCommand.ExecuteNonQuery();
                    
                }
                connection.Close();
            }
        }

        public void Delete(User user)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("id", System.Data.SqlDbType.Int).Value = user.ID;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Clear()
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "DELETE FROM Users";
            }
        }
    }
}
