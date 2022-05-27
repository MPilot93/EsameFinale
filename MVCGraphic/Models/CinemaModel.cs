

    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    namespace MVCGraphic.Models
    {
        public class CinemaModel
        {
            [Required]
            public int Room { get; set; }

            public decimal Value { get; set; }
        }
    }
