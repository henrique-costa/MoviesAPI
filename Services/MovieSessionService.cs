using AutoMapper;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.MovieSession;
using MoviesAPI.Models;
using System;
using System.Linq;

namespace MoviesAPI.Services
{
    public class MovieSessionService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieSessionService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadMovieSessionDTO Create(CreateMovieSessionDTO movieSessionDto)
        {
            MovieSession session = _mapper.Map<MovieSession>(movieSessionDto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return _mapper.Map<ReadMovieSessionDTO>(session);
        }

        internal ReadMovieSessionDTO GetById(int id)
        {
            MovieSession movieSession = _context.Sessions.FirstOrDefault(movieSession => movieSession.MovieSessionId == id);
            if (movieSession != null)
            {
                ReadMovieSessionDTO movieDTO = _mapper.Map<ReadMovieSessionDTO>(movieSession);

                return movieDTO;
            }
            return null;
        }
    }
}
