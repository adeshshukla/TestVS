using SWAN.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace SWAN.Helper
{
    public static class CustomApiResponse
    {

        public static HttpResponseMessage ToCustomApiResponse(this CustomResponse response)
        {
            return CreateCustomApiResponse(response);
        }

        public static HttpResponseMessage CreateCustomResponse(int status, string message = "")
        {
            return CreateCustomApiResponse(new CustomResponse()
            {
                Status = status,
                Result = message
            });
        }

        private static HttpResponseMessage CreateCustomApiResponse(CustomResponse response)
        {
            //ApiResponse apiResponse = new ApiResponse();
            HttpResponseMessage mainResponse = new HttpResponseMessage();
            switch (response.Status)
            {
                case 200:
                    response.Result = "OK";
                    mainResponse = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new ObjectContent<CustomResponse>(response, new JsonMediaTypeFormatter())
                    };
                    break;
                case 201:
                    response.Result = "Created.";
                    mainResponse = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Created,
                        Content = new ObjectContent<CustomResponse>(response, new JsonMediaTypeFormatter())
                    };
                    break;
                case 500:
                    response.Result = "Internal Server Error.Please Contact your Administrator.";
                    mainResponse = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Content = new ObjectContent<CustomResponse>(response, new JsonMediaTypeFormatter())
                    };
                    break;
                default:
                    response.Result = "Internal Server Error.Please Contact your Administrator.";
                    mainResponse = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Content = new ObjectContent<CustomResponse>(response, new JsonMediaTypeFormatter())
                    };
                    break;

            }

            //return new HttpResponseMessage()
            //{
            //    Content = new ObjectContent<ApiResponse>(apiResponse, new JsonMediaTypeFormatter())
            //};

            return mainResponse;
        }
    }

    //public class ApiResponse
    //{
    //    public HttpStatusCode StatusCode { get; set; }
    //    public string Result { get; set; }
    //    public object Content { get; set; }
    //    public Error Error { get; set; }
    //}

    //public class Error
    //{
    //    public Errors Errors { get; set; }
    //    public string Message { get; set; }
    //}

    //public class Errors
    //{
    //    public object Reason { get; set; }
    //    public string Message { get; set; }
    //}
}