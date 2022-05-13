using System;

namespace MoviesAPI.Data.DTO.MovieSession
{
    public class CreateMovieSessionDTO
    {
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public DateTime SessionEndingTime { get; set; }
    }
}
