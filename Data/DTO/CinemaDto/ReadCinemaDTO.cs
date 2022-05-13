using System.ComponentModel.DataAnnotations;
using MoviesAPI.Models;
namespace MoviesAPI.Data.DTO.CinemaDto
{
    public class ReadCinemaDTO
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public Manager Manager { get; set; }
    }
}
