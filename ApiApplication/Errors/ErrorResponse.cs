namespace ApiApplication.APIs.Errors
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }

        private string? GetDefaultMessageForStatusCode(int code)
        {
            return code switch
            {
                400 => "Bad Request",
                401 => "Not Authorized",
                404 => "Resources Not Found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
