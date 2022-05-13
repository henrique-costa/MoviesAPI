using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int CinemaId { get; set; }        
        [Required]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        [JsonIgnore]
        public virtual List<MovieSession> Sessions { get; set; }
    }
}
