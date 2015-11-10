namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HomeworkModel
    {
        public int Id { get; set; }

        [Required]
        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}