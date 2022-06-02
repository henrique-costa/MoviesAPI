using AutoMapper;
using FluentResults;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.MovieDTO;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadMovieDTO Create(CreateMovieDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return _mapper.Map<ReadMovieDTO>(movie);
        }

        public List<ReadMovieDTO> GetAll(int? ageRate)
        {
            List<Movie> movies;
            if (ageRate == null)
            {
                movies = _context.Movies.ToList();
            }
            else
            {
                movies = _context.Movies.Where(movie => movie.AgeRate <= ageRate).ToList();
            }

            if (movies != null)
            {
                List<ReadMovieDTO> readDto = _mapper.Map<List<ReadMovieDTO>>(movies);
                return readDto;
            }

            return null;
        }

        public ReadMovieDTO GetById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie != null)
            {
                ReadMovieDTO movieDTO = _mapper.Map<ReadMovieDTO>(movie);

                return movieDTO;
            }
            return null;
        }

        public Result Update(int id, UpdateMovieDTO movieToUpdateDTO)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie == null)
            {
                return Result.Fail("Movie not found");
            }
            _mapper.Map(movieToUpdateDTO, movie);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie == null)
            {
                return Result.Fail("Movie not found");
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
