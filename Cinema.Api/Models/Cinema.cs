using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cinema.Api.Models
{
    public class Cinema
    {
        [Required]
        public int Room { get; set; }

        public decimal Value { get; set; }
    }
}
