using System.Data.SqlClient;
using Cinema.Api.Models;

namespace Cinema.Api.SQL
{
    public class SpectatorSQL
    {
        private readonly string _connectionString;
        public SpectatorSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool IsOver(Spectator spectator)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Spectator WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", spectator.IdSpectator);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Spectator not registered");
            var result = new Spectator
            {
                IdSpectator = Convert.ToInt32(reader["IdSpectator"]),
                Name = reader["Name"].ToString(),
                Birth = Convert.ToDateTime(reader["Birth"]),
                IdTicket = Convert.ToInt32(reader["IdTicket"])
            };

            DateTime today = DateTime.Now;
            return today.Year - result.Birth.Year > 70;
        }

        public bool IsUnder(Spectator spectator)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Spectator WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", spectator.IdSpectator);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Spectator not registered");
            var result = new Spectator
            {
                IdSpectator = Convert.ToInt32(reader["IdSpectator"]),
                Name = reader["Name"].ToString(),
                Birth = Convert.ToDateTime(reader["Birth"]),
                IdTicket = Convert.ToInt32(reader["IdTicket"])
            };

            DateTime today = DateTime.Now;
            return today.Year - result.Birth.Year < 14;
        }
        public bool IsPlusUnder(Spectator spectator)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Spectator WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", spectator.IdSpectator);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Spectator not registered");
            var result = new Spectator
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
