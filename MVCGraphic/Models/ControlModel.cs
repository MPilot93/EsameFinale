using System.ComponentModel.DataAnnotations;


namespace MVCGraphic.Models
{
    public class ControlModel : SpectatorModel
    {
        [Required]
        public int IdFilm { get; set; }
        [Required]
        public string Genre { get; set; }


    }
}
