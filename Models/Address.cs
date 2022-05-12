using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Neighbor { get; set; }
        public int Number { get; set; }
        public Cinema Cinema { get; set; }
    }
}
