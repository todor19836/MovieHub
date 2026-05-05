using System.ComponentModel.DataAnnotations;

namespace MovieHub.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; } = string.Empty;

        public int Year { get; set; }

        public double Rating { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}