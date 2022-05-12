using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.Address;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = address.AddressId }, address);
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
                ReadMovieDTO movieDTO = _mapper.Map<ReadMovieDTO>(movie);

                return Ok(movieDTO);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateMovieDTO movieToUpdateDTO)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieToUpdateDTO, movie);
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
