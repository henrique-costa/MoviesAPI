using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.AddressDto
{
    public class CreateAddressDTO
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
