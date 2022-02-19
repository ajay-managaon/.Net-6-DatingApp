namespace Web.DatingApp.API.Web.DatingApp.ExceptionHandling
{
    public class ApiException
    {
        public ApiException(int statusCode, string? message = null, string? details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? Details { get; set; } = string.Empty ;
    }
}
