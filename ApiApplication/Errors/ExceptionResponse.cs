namespace ApiApplication.APIs.Errors
{
    public class ExceptionResponse : ErrorResponse
    {
        public string? Details { get; set; }

        public ExceptionResponse(int code, string? message = null, string? details = null):base(code, message)
        {
            Details = details;
        }
    }
}
