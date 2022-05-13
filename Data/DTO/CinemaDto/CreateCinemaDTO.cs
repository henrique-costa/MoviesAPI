using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.CinemaDto
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "The field Name is mandatory")]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}
