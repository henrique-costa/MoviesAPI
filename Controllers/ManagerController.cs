using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.ManagerDTO;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateManagerDTO managerDTO)
        {
            ReadManagerDTO readManagerDTO = _managerService.Create(managerDTO);
            return CreatedAtAction(nameof(GetById), new { Id = readManagerDTO.ManagerId }, readManagerDTO);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ReadManagerDTO readManagerDTO = _managerService.GetById(id);
            if (readManagerDTO == null) return NotFound();
            
            return Ok(readManagerDTO);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Result result = _managerService.Delete(id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
