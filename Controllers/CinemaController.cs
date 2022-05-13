using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.CinemaDto;
using MoviesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {


        private MovieContext _context;
        private IMapper _mapper;

        public CinemaController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = cinema.CinemaId }, cinema);
        }

        [HttpGet]
        public IEnumerable<Cinema> GetAll()
        {
            return _context.Cinemas;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.CinemaId == id);
            if (cinema != null)
            {
                ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);

                return Ok(cinemaDTO);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateCinemaDTO cinemaToUpdateDTO)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.CinemaId == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaToUpdateDTO, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.CinemaId == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

