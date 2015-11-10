namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }
    }
}