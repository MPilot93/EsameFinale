using System.Data.SqlClient;
using MVCGraphic.Models;


namespace MVCGraphic.SQL
{
    public class TicketSQL
    {
        private readonly string _connectionString;
        public TicketSQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TicketModel GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Ticket WHERE Id=@Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                throw new Exception("No Ticket found");

            return new TicketModel
            {
                IdTicket = Convert.ToInt32(reader["IdTicket"]),
                Seat = Convert.ToInt32(reader["Seat"]),
                Price = Convert.ToDecimal(reader["Price"])
            };


        }

        public void Add(TicketModel ticket)
        {

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = @"insert into Ticket ([IdTicket],[Seat],[Price])
                        values(@IdTicket, @Seat, @Price)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("IdTicket", ticket.IdTicket);
            command.Parameters.AddWithValue("Seat", ticket.Seat);
            command.Parameters.AddWithValue("Price", ticket.Price);

            command.ExecuteNonQuery();
        }
    }
}
