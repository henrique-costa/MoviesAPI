using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.AddressDto;
using MoviesAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == id);
            if (address != null)
            {
                ReadAddressDTO addressDTO = _mapper.Map<ReadAddressDTO>(address);

                return Ok(addressDTO);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateAddressDTO addressToUpdateDTO)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(addressToUpdateDTO, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
