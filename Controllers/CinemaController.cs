using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.CinemaDto;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {


        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO readCinemaDTO = _cinemaService.Create(cinemaDTO);
            
            return CreatedAtAction(nameof(GetById), new { Id = readCinemaDTO.CinemaId }, cinemaDTO);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string movieName)
        {
            List<ReadCinemaDTO> readCinemaDTO = _cinemaService.GetAll(movieName);
            if (readCinemaDTO != null)
            {
                return Ok(readCinemaDTO);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ReadCinemaDTO readCinemaDTO = _cinemaService.GetById(id);
            if (readCinemaDTO != null)
            {
                return Ok(readCinemaDTO);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateCinemaDTO cinemaToUpdateDTO)
        {
            Result result = _cinemaService.Update(id, cinemaToUpdateDTO);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Result result = _cinemaService.Delete(id);
            if (result.IsFailed) return NotFound();
            
            return NoContent();
        }
    }
}

