using System.ComponentModel.DataAnnotations;
using MoviesAPI.Models;
namespace MoviesAPI.Data.DTO.CinemaDto
{
    public class ReadCinemaDTO
    {
        [Key]
        [Required]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "The field Name is mandatory")]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
