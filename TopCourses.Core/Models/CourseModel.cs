﻿namespace TopCourses.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using TopCourses.Infrastructure.Data.Models;

    public class CourseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Subtitle { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        public ICollection<Requirement> Requirements { get; set; } = new HashSet<Requirement>();

        public ICollection<Goal> Goals { get; set; } = new HashSet<Goal>();

        public ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();

        public ICollection<Section> Curriculum { get; set; } = new HashSet<Section>();

        public Level Level { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }
    }
}