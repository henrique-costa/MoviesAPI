using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.CinemaDto
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "The field Name is mandatory")]
        public string Name { get; set; }
    }
}
