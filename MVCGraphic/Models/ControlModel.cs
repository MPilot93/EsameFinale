using System.ComponentModel.DataAnnotations;


namespace MVCGraphic.Models
{
    public class ControlModel : SpectatorModel
    {
        [Required]
        public string Genre { get; set; }


    }
}
