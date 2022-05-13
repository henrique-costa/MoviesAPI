using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public int AgeRate { get; set; }
        [JsonIgnore]
        public virtual List<MovieSession> Sessions { get; set; }
    }
}
