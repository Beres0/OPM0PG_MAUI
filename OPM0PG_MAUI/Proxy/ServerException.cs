using System.Net;
using WSH_HomeAssignment.Api.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public class ValidationErrorDto
    {
      public Dictionary<string,string> Errors { get; set; }
        public override string ToString()
        {
            return string.Join("\n", Errors.Values);
        }
    }
    public class ServerException:Exception
    {
        public string Error { get; }
        HttpStatusCode StatusCode { get; }
        public ServerException(ErrorDto error,HttpStatusCode statusCode):base($"Server {statusCode}: {error.Message}")
        {
            Error = error.Message;
            StatusCode = statusCode;
        }
        public ServerException(ValidationErrorDto error, HttpStatusCode statusCode):base($"Server {statusCode}: {error}")
        {
            Error = error.ToString();
            StatusCode = statusCode;
        }
        public ServerException(HttpStatusCode statusCode,string message) : base($"Server {statusCode}: {message}")
        {
            Error = message;
            StatusCode = statusCode;
        }
    }
}
