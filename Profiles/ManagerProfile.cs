using AutoMapper;
using MoviesAPI.Data.DTO.ManagerDTO;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDTO, Manager>();
            CreateMap<Manager, ReadManagerDTO>()
                .ForMember(manager => manager.Cinemas, opts => opts
                .MapFrom(manager => manager.Cinemas.Select
                (c => new { c.CinemaId, c.Name, c.Address, c.AddressId})));
        }
    }
}
