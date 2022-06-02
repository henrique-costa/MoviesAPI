using AutoMapper;
using FluentResults;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.AddressDto;
using MoviesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Services
{
    public class AddressService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AddressService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAddressDTO Create(CreateAddressDTO addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return _mapper.Map<ReadAddressDTO>(addressDto);
        }

        public List<ReadAddressDTO> GetAll()
        {
            List<Address> addresses = _context.Addresses.ToList();
            if (addresses == null)
            {
                return null;
            }
            return _mapper.Map<List<ReadAddressDTO>>(addresses);
        }

        public ReadAddressDTO GetById(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == id);
            if (address != null)
            {
                ReadAddressDTO addressDTO = _mapper.Map<ReadAddressDTO>(address);

                return addressDTO;
            }
            return null;
        }

        public Result Update(int id, UpdateAddressDTO addressDto)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == id);
            if (address == null)
            {
                return Result.Fail("Address not found");
            }
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.AddressId == id);
            if (address == null)
            {
                return Result.Fail("Address not found");
            }
            _context.Remove(address);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
