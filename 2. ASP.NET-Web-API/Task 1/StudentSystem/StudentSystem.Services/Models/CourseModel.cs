﻿namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CourseModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}