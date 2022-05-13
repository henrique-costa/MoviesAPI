using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.MovieSession;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieSessionController : ControllerBase
    {
        private IMapper _mapper;
        private MovieContext _context;

        public MovieSessionController(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(CreateMovieSessionDTO movieSessionDTO)
        {
            MovieSession movieSession = _mapper.Map<MovieSession>(movieSessionDTO);
            _context.Sessions.Add(movieSession);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = movieSession.MovieSessionId}, movieSession);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            MovieSession movieSession = _context.Sessions.FirstOrDefault(movieSession => movieSession.MovieSessionId == id);
            if (movieSession != null)
            {
                ReadMovieSessionDTO movieDTO = _mapper.Map<ReadMovieSessionDTO>(movieSession);

                return Ok(movieDTO);
            }
            return NotFound();
        }
    }
}
