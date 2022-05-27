using System.Data.SqlClient;
using MVCGraphic.Models;

namespace MVCGraphic.SQL
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

        public decimal GetTotal()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            List<CinemaModel> list = new List<CinemaModel>();
            var query = "SELECT [Room], [Value] FROM Cinema;";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var result = new CinemaModel();

                result.Room = Convert.ToInt32(reader["Room"]);
                result.Value = Convert.ToDecimal(reader["Value"]);
                list.Add(result);
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += item.Value;
            }
            return total;
        }
    }
}
