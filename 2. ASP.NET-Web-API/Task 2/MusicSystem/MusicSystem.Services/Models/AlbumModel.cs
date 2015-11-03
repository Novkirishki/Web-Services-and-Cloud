namespace MusicSystem.Services.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AlbumModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public decimal Profit { get; set; }
    }
}