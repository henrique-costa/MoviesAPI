using MoviesAPI.Models;
using System;

namespace MoviesAPI.Data.DTO.MovieSession
{
    public class ReadMovieSessionDTO
    {
        public int MovieSessionId { get; set; }
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
        public DateTime SessionEndingTime { get; set; }
        public DateTime SessionBegginingTime { get; set; }
    }
}
