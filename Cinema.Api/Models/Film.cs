using System.ComponentModel.DataAnnotations;


namespace Cinema.Api.Models
{
    public class Film
    {
        [Required]
        public int IdFilm { get; set; }
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Minutes { get; set; }
    }
}
