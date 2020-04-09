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
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _repo;
        private readonly IMapper _mapper;
        public SemesterService(ISemesterRepository repo)
        {
            this._repo = repo;

            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<AppProfile>();
                cfg.CreateMap<Semester, MasterModel>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public CustomResponse GetAllSemesters()
        {
            return _repo.GetAll();
        }

        public CustomResponse InsertSemester(MasterModel _semester)
        {
            Semester semester = _mapper.Map<Semester>(_semester);
            semester.CreateTs = DateTime.Now;
            semester.IsActive = true;
            return _repo.Insert(semester);
        }        
    }
}
