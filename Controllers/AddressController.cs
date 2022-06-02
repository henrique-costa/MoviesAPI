using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.AddressDto;
using MoviesAPI.Models;
using MoviesAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAddressDTO addressDTO)
        {
            ReadAddressDTO readDto = _addressService.Create(addressDTO);
            return CreatedAtAction(nameof(GetById), new { Id = readDto.AddressId }, readDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReadAddressDTO> readDto = _addressService.GetAll();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ReadAddressDTO readAddressDTO = _addressService.GetById(id);
            if (readAddressDTO == null) return NotFound();
            return Ok(readAddressDTO);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateAddressDTO addressToUpdateDTO)
        {
            Result result = _addressService.Update(id, addressToUpdateDTO);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Result result = _addressService.Delete(id);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
