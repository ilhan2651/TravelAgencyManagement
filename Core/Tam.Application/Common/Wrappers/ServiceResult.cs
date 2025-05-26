using System.Text.Json.Serialization;
using System.Net;


namespace Tam.Application.Common.Wrappers
{
    public class ServiceResult
    {
        public List<string> Messages { get; set; } = new();
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string? UrlAsCreated { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Success;

        [JsonIgnore]
        public bool IsFail => !Success;


        public static ServiceResult Ok(string? message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ServiceResult
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Messages = message != null ? [message] : []
            };
        }
        public static ServiceResult Created(string urlAsCreated, string? message = null)
        {
            return new ServiceResult
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                UrlAsCreated = urlAsCreated,
                Messages = message != null ? [message] : []
            };
        }
        public static ServiceResult Fail(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                Success = false,
                StatusCode = statusCode,
                Messages = errors
            };
        }
        public static ServiceResult Fail(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return Fail(new List<string> { error }, statusCode);
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public static ServiceResult<T> Ok(T data, string? message = null)
        {
            return new ServiceResult<T>
            {
                Success = true,
                Data = data,
                StatusCode = HttpStatusCode.OK,
                Messages = message != null ? [message] : []
            };
        }

        public static ServiceResult<T> Created(T data, string urlAsCreated, string? message = null)
        {
            return new ServiceResult<T>
            {
                Success = true,
                Data = data,
                UrlAsCreated = urlAsCreated,
                StatusCode = HttpStatusCode.Created,
                Messages = message != null ? [message] : []
            };
        }

        public static new ServiceResult<T> Fail(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                Success = false,
                StatusCode = status,
                Messages = errors
            };
        }

        public static new ServiceResult<T> Fail(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return Fail(new List<string> { error }, status);
        }
    }



}
