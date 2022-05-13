using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [StringLength(30)]
        public string Genre { get; set; }
        [Range(1, 400)]
        public int Duration { get; set; }

    }
}
