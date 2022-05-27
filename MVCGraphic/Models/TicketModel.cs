using System.ComponentModel.DataAnnotations;
namespace MVCGraphic.Models
{
    public class TicketModel
    {
        [Required]
        public int IdTicket { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
    }
}
