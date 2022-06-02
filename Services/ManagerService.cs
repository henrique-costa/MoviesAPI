using AutoMapper;
using FluentResults;
using MoviesAPI.Data;
using MoviesAPI.Data.DTO.ManagerDTO;
using MoviesAPI.Models;
using System;
using System.Linq;

namespace MoviesAPI.Services
{
    public class ManagerService
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public ManagerService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadManagerDTO Create(CreateManagerDTO managerDTO)
        {
            Manager manager = _mapper.Map<Manager>(managerDTO);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return _mapper.Map<ReadManagerDTO>(managerDTO);

        }

        public ReadManagerDTO GetById(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.ManagerId == id);
            if (manager != null)
            {
                ReadManagerDTO managerDTO = _mapper.Map<ReadManagerDTO>(manager);

                return managerDTO;
            }
            return null;
        }

        public Result Delete(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.ManagerId == id);
            if (manager == null)
            {
                return Result.Fail("Manager not found");
            }
            _context.Remove(manager);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
