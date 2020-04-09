using SWAN.Common.Models;
using SWAN.Common.Response;
using SWAN.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SWAN.Controllers
{
    public class SemesterController : ApiController
    {
        private readonly ISemesterService _service;
        public SemesterController(ISemesterService service)
        {
            _service = service;
        }

        [HttpGet]
        // GET: api/Semester/GetAllSemesters
        public CustomResponse GetAllSemesters()
        {
            return _service.GetAllSemesters();
        }
        [HttpPost]
        public CustomResponse InsertSemester([FromBody]MasterModel value)
        {
            return _service.InsertSemester(value);
        }
    }
}
