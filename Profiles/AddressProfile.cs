using AutoMapper;
using MoviesAPI.Data.DTO.AddressDto;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, ReadAddressDTO>();
            CreateMap<UpdateAddressDTO, Address>();
        }
    }
}
