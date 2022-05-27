using System.Data.SqlClient;
using MVCGraphic.Models;

namespace MVCGraphic.SQL
{
    public class RoomSQL
    {
        private readonly string _connectionString;
        public RoomSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<RoomModel> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "SELECT * FROM Rooms;";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new RoomModel
                {
                    IdRoom = Convert.ToInt32(reader["IdRoom"]),
                    Nseats = Convert.ToInt32(reader["NSeats"]),
                    Occupied = Convert.ToInt32(reader["Occupied"]),
                    IdFilm = Convert.ToInt32(reader["IdFilm"]),
                    Value = Convert.ToDecimal(reader["Value"])
                };
            }
        }

        public void Empty(RoomModel room)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = @"UPDATE Rooms
                            SET Occupied = 0,
                                Value = 0
                            WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("Occupied", room.Occupied);
            command.Parameters.AddWithValue("Value", room.Value);

            command.ExecuteNonQuery();
        }
    }
}

