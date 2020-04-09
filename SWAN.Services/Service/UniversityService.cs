using AutoMapper;
using SWAN.Common.Models;
using SWAN.Common.Response;
using SWAN.Data;
using SWAN.Repository.Interfaces;
using SWAN.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services.Service
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _repo;
        private readonly IMapper _mapper;
        public UniversityService(IUniversityRepository repo)
        {
            this._repo = repo;

            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<AppProfile>();
                cfg.CreateMap<University, MasterModel>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public CustomResponse GetAllUniversities()
        {
            return _repo.GetAll();
        }

        public CustomResponse InsertUniversity(MasterModel _university)
        {
            University university = _mapper.Map<University>(_university);
            university.CreateTs = DateTime.Now;
            university.IsActive = true;
            return _repo.Insert(university);
        }        
    }
}
