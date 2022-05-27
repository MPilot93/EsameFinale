using System.ComponentModel.DataAnnotations;


namespace Cinema.Api.Models
{
    public class Ticket
    {
        [Required]
        public int IdTicket { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
    }
}
