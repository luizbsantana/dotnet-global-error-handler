using System.Net;

namespace ls_global_error_handler.CustomExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }

        public BusinessException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}