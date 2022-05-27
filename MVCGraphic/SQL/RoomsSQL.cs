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

        public decimal GetTotal()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            List<RoomModel> list = new List<RoomModel>();
            var query = "SELECT * FROM Rooms;";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var result = new RoomModel();

                result.IdRoom = Convert.ToInt32(reader["IdRoom"]);
                result.Nseats = Convert.ToInt32(reader["NSeats"]);
                result.Occupied = Convert.ToInt32(reader["Occupied"]);
                result.IdFilm = Convert.ToInt32(reader["IdFilm"]);
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

        public decimal GetTotalById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            List<RoomModel> list = new List<RoomModel>();
            var query = "SELECT * FROM Rooms where IdRoom=id";

            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            var result = Convert.ToDecimal(reader["Value"]);
            return result;
        }

        public void Empty(int ID )
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = @"UPDATE Rooms
                            SET Occupied = 0,
                                Value = 0
                            WHERE IdRoom = @ID";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Id", ID);


            command.ExecuteNonQuery();
        }

        public void EmptyAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = @"UPDATE Rooms
                            SET Occupied = 0,
                                Value = 0";
            using var command = new SqlCommand(query, connection);
            


            command.ExecuteNonQuery();
        }
    }



}

