using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.AddressDto
{
    public class UpdateAddressDTO
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
