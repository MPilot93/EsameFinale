using System.ComponentModel.DataAnnotations;


namespace Cinema.Api.Models
{
    public class Spectator
    {
        [Required]
        public int IdSpectator { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        public int IdTicket { get; set; }
    }
}
