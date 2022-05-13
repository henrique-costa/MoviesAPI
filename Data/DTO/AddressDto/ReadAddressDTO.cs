using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.AddressDto
{
    public class ReadAddressDTO
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
    }
}
