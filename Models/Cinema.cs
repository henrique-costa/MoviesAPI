using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "The field Name is mandatory")]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
