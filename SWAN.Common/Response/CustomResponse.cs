using System.Collections.Generic;

namespace SWAN.Common.Response
{
    public class CustomResponse
    {
        public int Status { get; set; }
        public string Result { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }
        public CustomResponse()
        { }

        public CustomResponse(int status, object data = null, List<string> errors = null)
        {
            Status = status;
            Data = data;
            Errors = errors ?? new List<string>();
        }

    }
}

