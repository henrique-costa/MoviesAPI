using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private static List<Movie> movies = new List<Movie>();
        private static int id = 1;
        [HttpPost]
        public IActionResult Create([FromBody] Movie movie)
        {
            movie.MovieId = id++;
            movies.Add(movie);
            Console.WriteLine(movie.Title);
            return CreatedAtAction(nameof(GetById), new { Id = movie.MovieId}, movies);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Movie movie = movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
    }
}
