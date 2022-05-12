using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = movie.MovieId}, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Movie movieToUpdate)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            movie.Title = movieToUpdate.Title;
            movie.Director = movieToUpdate.Director;
            movie.Duration = movieToUpdate.Duration;
            movie.Genre = movieToUpdate.Genre;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
