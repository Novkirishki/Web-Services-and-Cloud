namespace StudentSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TestModel
    {
        public int Id { get; set; }

        public ICollection<StudentModel> Students { get; set; }

        [Required]
        public Guid CourseId { get; set; }
    }
}