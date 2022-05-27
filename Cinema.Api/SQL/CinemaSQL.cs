using System.Data.SqlClient;
using Cinema.Api.Models;

namespace Cinema.Api.SQL
{
    public class CinemaSQL
    {
        private readonly string _connectionString;
        public CinemaSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CinemaModel> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT [Room], [Value] FROM Cinema;";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CinemaModel
                {
                    Room = Convert.ToInt32(reader["Room"]),
                    Value = Convert.ToDecimal(reader["Value"])
                };
            }
        }

        
    }
}
