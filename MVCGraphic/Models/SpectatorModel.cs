using System.ComponentModel.DataAnnotations;
namespace MVCGraphic.Models
{
    public class SpectatorModel
    {
        [Required]
        public int IdSpectator { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        public int IdTicket { get; set; }
    }
}
