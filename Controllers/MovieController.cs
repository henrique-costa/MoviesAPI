﻿using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.MovieDTO;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieDTO movieDTO)
        {
            ReadMovieDTO readMovieDTO = _movieService.Create(movieDTO);            
            return CreatedAtAction(nameof(GetById), new { Id = readMovieDTO.MovieId}, readMovieDTO);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int? ageRate = null)
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
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ReadMovieDTO readMovieDTO = _movieService.GetById(id);
            if (readMovieDTO != null)
            {
                return Ok(readMovieDTO);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateMovieDTO movieToUpdateDTO)
        {
            Result result = _movieService.Update(id, movieToUpdateDTO);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Result result = _movieService.Delete(id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
