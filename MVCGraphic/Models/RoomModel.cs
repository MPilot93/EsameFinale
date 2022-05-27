using System.ComponentModel.DataAnnotations;

namespace MVCGraphic.Models
{
    public class RoomModel
    {
        [Required]
        public int IdRoom { get; set; }
        public int Nseats { get; set; }
        public int Occupied { get; set; }
        public int IdFilm { get; set; }
        public decimal Value { get; set; }
    }
}
