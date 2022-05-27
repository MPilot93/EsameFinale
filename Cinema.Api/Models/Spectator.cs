using System.ComponentModel.DataAnnotations;


namespace Cinema.Api.Models
{
    public class Spectator
    {
        [Required]
        public int IdSpectator { get; set; }
        public int Name { get; set; }
        [Required]
        public DateOnly Birth { get; set; }
        public int IdTicket { get; set; }
    }
}
