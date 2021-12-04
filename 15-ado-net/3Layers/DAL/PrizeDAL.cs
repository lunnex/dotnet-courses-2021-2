using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DALDB
{
    public class PrizeDAL : IPrizeDAL
    {
        private readonly string _connectoinString;

        public PrizeDAL(string connectionString)
        {
            _connectoinString = connectionString;
        }

        public List<Prize> GetAll()
        {
            var prizes = new List<Prize>();

            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT* FROM Prizes";
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Prize prize = new Prize(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    prizes.Add(prize);
                }
                //connection.Close();
            }
            return prizes;
        }

        public void Add(Prize prize)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                //command.CommandText = $"EXEC AddPrize '{prize.Title}', '{prize.Description}'";
                command.CommandText = "AddPrize";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("title", System.Data.SqlDbType.NVarChar).Value = prize.Title;
                command.Parameters.Add("description", System.Data.SqlDbType.NVarChar).Value = prize.Description;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(Prize newPrize)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                //command.CommandText = $"EXEC EditPrize '{oldPrize.ID}', '{newPrize.Title}', '{newPrize.Description}' ";
                command.CommandText = "EditPrize";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("id", System.Data.SqlDbType.Int).Value = newPrize.ID;
                command.Parameters.Add("title", System.Data.SqlDbType.NVarChar).Value = newPrize.Title;
                command.Parameters.Add("description", System.Data.SqlDbType.NVarChar).Value = newPrize.Description;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                //command.CommandText = $"EXEC DeletePrize '{prize.ID}'";
                command.CommandText = "DeletePrize";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Prize Get(int id)
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "getPrize";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("id", System.Data.SqlDbType.Int).Value = id;
                connection.Open();

                var reader = command.ExecuteReader();
                reader.Read();
                
                    Prize prize = new Prize(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    return prize;
                

            }
        }

        public void Clear()
        {
            using (var connection = new SqlConnection(_connectoinString))
            {
                var command = connection.CreateCommand();
                connection.Open();
                command.CommandText = "DELETE FROM Prizes";
            }
        }
    }
}
