using Microsoft.AspNetCore.Authentication;

namespace EShop.API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message =null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request , you have made",
                401 => "Authorized , you are not",
                404 => "Resource found , it was not",
                500 => "an Error was occured"
            };
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
