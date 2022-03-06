using System.Net;

namespace ls_global_error_handler.CustomExceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }

        public DomainException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}