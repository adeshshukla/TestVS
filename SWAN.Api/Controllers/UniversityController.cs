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
    public class UniversityController : ApiController
    {
        private readonly IUniversityService _service;
        public UniversityController(IUniversityService service)
        {
            _service = service;
        }

        [HttpGet]
        // GET: api/University/GetAllSessions
        public CustomResponse GetAllUniversities()
        {
            return _service.GetAllUniversities();
        }
        [HttpPost]
        public CustomResponse InsertUniversity([FromBody]MasterModel value)
        {
            return _service.InsertUniversity(value);
        }
    }
}
