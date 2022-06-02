using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.MovieSession;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieSessionController : ControllerBase
    {
        private MovieSessionService _movieSessionService;

        public MovieSessionController(MovieSessionService movieSessionService)
        {
            _movieSessionService = movieSessionService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieSessionDTO movieSessionDTO)
        {
            ReadMovieSessionDTO readMovieSessionDTO = _movieSessionService.Create(movieSessionDTO);
            return CreatedAtAction(nameof(GetById), new { Id = readMovieSessionDTO.MovieSessionId}, readMovieSessionDTO);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ReadMovieSessionDTO readDto = _movieSessionService.GetById(id);
            if (readDto == null)
            {
                return NotFound();
            }
            return Ok(readDto);
        }
    }
}
