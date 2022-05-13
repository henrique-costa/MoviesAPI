using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.ManagerDTO;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public ManagerController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateManagerDTO managerDTO)
        {
            Manager manager = _mapper.Map<Manager>(managerDTO);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = manager.ManagerId }, manager);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.ManagerId == id);
            if (manager != null)
            {
                ReadManagerDTO managerDTO = _mapper.Map<ReadManagerDTO>(manager);

                return Ok(managerDTO);
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.ManagerId == id);
            if (manager == null)
            {
                return NotFound();
            }
            _context.Remove(manager);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
