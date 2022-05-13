using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Manager
    {
        [Key]
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }

    }
}
