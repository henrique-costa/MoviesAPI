using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTO.MovieDTO
{
    public class ReadMovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int AgeRate { get; set; }
        public DateTime TimeOfInquiry { get; set; } = DateTime.Now;
    }
}
