namespace MusicSystem.Services.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArtistModel
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }
    }
}