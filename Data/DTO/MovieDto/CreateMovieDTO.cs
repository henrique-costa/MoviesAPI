using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.MovieDTO
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The title is required")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "The genre cant be longer than 30 characters")]
        public string Genre { get; set; }
        [Range(1, 400, ErrorMessage = "The duration must be between 1 - 400 minutes")]
        public int Duration { get; set; }
    }
}
