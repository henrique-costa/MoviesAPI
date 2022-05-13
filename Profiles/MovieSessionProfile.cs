using AutoMapper;
using MoviesAPI.Data.DTO.MovieSession;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieSessionProfile : Profile
    {
        public MovieSessionProfile()
        {
            CreateMap<CreateMovieSessionDTO, MovieSession>();
            CreateMap<MovieSession, ReadMovieSessionDTO>()
                .ForMember(dto => dto.SessionBegginingTime, opts => opts
                .MapFrom(dto =>
                dto.SessionEndingTime.AddMinutes(dto.Movie.Duration * (-1))));
        }
    }
}
