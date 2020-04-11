using SWAN.Common.Models;
using SWAN.Common.Response;
using SWAN.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SWAN.Helper;

namespace SWAN.Controllers
{
    public class SessionController : ApiController
    {
        private readonly ISessionService _service;
        public SessionController(ISessionService service)
        {
            _service = service;
        }

        [HttpGet]
        // GET: api/Session/GetAllSessions
        public HttpResponseMessage GetAllSessions()
        {
            //throw new ArgumentNullException();

            //return _service.GetAllSessions().ToCustomApiResponse();

            var data = _service.GetAllSessions();
            return Request.CreateCustomResponse(data);
        }

        public CustomResponse GetAllSessions1()
        {            
            return _service.GetAllSessions();

        }

        [HttpPost]
        public CustomResponse InsertSession([FromBody]SessionModel value)
        {
            return _service.InsertSession(value);
        }

        [HttpPost]
        public CustomResponse DeleteSessionBySessionId(int value)
        {
            return _service.DeleteSessionBySessionId(value);
        }

        #region Commented Code
        //[HttpGet]
        ////[Route("api/Session/GetSessionBrief")]
        //public CustomResponse GetSessionBrief()
        //{
        //    return _service.GetSessionBrief();
        //} 
        #endregion
    }
}
