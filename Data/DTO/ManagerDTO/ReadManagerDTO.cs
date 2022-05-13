using MoviesAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.ManagerDTO
{
    public class ReadManagerDTO
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public object Cinemas { get; set; }
    }
}
