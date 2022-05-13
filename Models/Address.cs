﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
