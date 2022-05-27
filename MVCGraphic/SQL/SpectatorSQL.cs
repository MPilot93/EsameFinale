using System.Data.SqlClient;
using MVCGraphic.Models;

namespace MVCGraphic.SQL
{
    public class SpectatorSQL
    {
        private readonly string _connectionString;
        public SpectatorSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(SpectatorModel spectator)
        {
            string sql = @"insert into [Cinema].[dbo].[Spectator]
                        ([Name],[Birth],[IdTicket])
                        values(@Name,@Birth,@IdTicket)";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", spectator.Name);
            command.Parameters.AddWithValue("@Birth", spectator.Birth);
            command.Parameters.AddWithValue("@IdTicket", spectator.IdTicket);
            return command.ExecuteNonQuery();

        }

        public bool IsOver(SpectatorModel spectator)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Spectator WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", spectator.IdSpectator);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Spectator not registered");
            var result = new SpectatorModel
            {
                IdSpectator = Convert.ToInt32(reader["IdSpectator"]),
                Name = reader["Name"].ToString(),
                Birth = Convert.ToDateTime(reader["Birth"]),
                IdTicket = Convert.ToInt32(reader["IdTicket"])
            };

            DateTime today = DateTime.Now;
            return today.Year - result.Birth.Year > 70;
        }

        public bool IsUnder(SpectatorModel spectator)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Spectator WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", spectator.IdSpectator);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Spectator not registered");
            var result = new SpectatorModel
            {
                IdSpectator = Convert.ToInt32(reader["IdSpectator"]),
                Name = reader["Name"].ToString(),
                Birth = Convert.ToDateTime(reader["Birth"]),
                IdTicket = Convert.ToInt32(reader["IdTicket"])
            };

            DateTime today = DateTime.Now;
            return today.Year - result.Birth.Year < 14;
        }
        public bool IsPlusUnder(SpectatorModel spectator)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Spectator WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", spectator.IdSpectator);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Spectator not registered");
            var result = new SpectatorModel
            {
                IdSpectator = Convert.ToInt32(reader["IdSpectator"]),
                Name = reader["Name"].ToString(),
                Birth = Convert.ToDateTime(reader["Birth"]),
                IdTicket = Convert.ToInt32(reader["IdTicket"])
            };

            DateTime today = DateTime.Now;
            return today.Year - result.Birth.Year < 5;
        }


    }
}

