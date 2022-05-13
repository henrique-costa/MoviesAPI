using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.ManagerDTO
{
    public class CreateManagerDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
