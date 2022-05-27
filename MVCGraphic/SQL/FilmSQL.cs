using System.Data.SqlClient;
using MVCGraphic.Models;


namespace MVCGraphic.SQL
{
    public class FilmSQL
    {
        private readonly string _connectionString;
        public FilmSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public FilmModel GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Film WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                throw new Exception("No product found");

            return new FilmModel
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
