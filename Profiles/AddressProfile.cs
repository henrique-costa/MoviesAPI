using AutoMapper;
using MoviesAPI.Data.DTO.Address;
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
