using AutoMapper;
using FluentResults;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.CinemaDto;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Services
{
    public class CinemaService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public CinemaService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDTO Create(CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDTO>(cinema);
        }

        internal List<ReadCinemaDTO> GetAll(string movieName)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(movieName))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessions.Any(MovieSession => MovieSession.Movie.Title == movieName)
                                            select cinema;
                cinemas = query.ToList();
            }
            return _mapper.Map<List<ReadCinemaDTO>>(cinemas);

        }

        public ReadCinemaDTO GetById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.CinemaId == id);
            if (cinema != null)
            {
                ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);

                return cinemaDTO;
            }
            return null;
        }

        public Result Update(int id, UpdateCinemaDTO cinemaToUpdateDTO)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.CinemaId == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema not found");
            }
            _mapper.Map(cinemaToUpdateDTO, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.CinemaId == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema not found");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
