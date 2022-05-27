using System.ComponentModel.DataAnnotations;

namespace Cinema.Api.Models
{
    public class Rooms
    {
        [Required]
        public int IdRoom { get; set; }
        public int Nseats { get; set; }
        public int IdFilm { get; set; }
        public decimal Value { get; set; }
    }
}
