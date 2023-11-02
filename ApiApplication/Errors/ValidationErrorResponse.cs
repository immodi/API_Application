namespace ApiApplication.APIs.Errors
{
    public class ValidationErrorResponse : ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ValidationErrorResponse():base(400)
        {
            Errors = new List<string>();
        }
    }
}
