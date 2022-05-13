using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }
        [Required]
        [StringLength(30)]
        public string Street { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        public int Number { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
