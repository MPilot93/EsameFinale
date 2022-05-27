using System.Data.SqlClient;
using Cinema.Api.Models;


namespace Cinema.Api.SQL
{
    public class FilmSQL
    {
        private readonly string _connectionString;
        public FilmSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Film GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Film WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                throw new Exception("No product found");

            return new Film
            {
                IdFilm = Convert.ToInt32(reader["IdFilm"]),
                Title = reader["Title"].ToString(),
                Genre = reader["Genre"].ToString(),
                Director = reader["Director"].ToString(),
                Minutes = Convert.ToInt32(reader["Minutes"])
            };
        }
    }

}
