namespace EShop.API.Errors
{
    public class APIValidationErrorResponse : APIResponse
    {
        public APIValidationErrorResponse() : base(400,"Validation Error")
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
