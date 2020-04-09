using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Common.Response
{
    public class CustomResponse
    {
        public CustomResponse(int status)
        {
            this.Status = status;
        }
        public CustomResponse()
        {

        }

        public int Status { get; set; }
        public object Data { get; set; }
        public object Type { get; set; }
        public List<string> Errors { get; set; }
        public string Result { get; set; }
        public string ReasonCode { get; set; }

    }
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        //public string Message { get; set; }
        public string Result { get; set; }
        public string ReasonCode { get; set; }
        public object Content { get; set; }
        public Error Error { get; set; }
    }
    public class Error
    {
        public Errors Errors { get; set; }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }
    public class Errors
    {
        public object Reason { get; set; }
        public string Message { get; set; }
    }

}

