using AutoMapper;
using MoviesAPI.Data.DTO.Movie;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<Movie, ReadMovieDTO>();
            CreateMap<UpdateMovieDTO, Movie>();

        }
    }
}
