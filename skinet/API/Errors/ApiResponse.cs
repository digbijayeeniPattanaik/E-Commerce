namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            string errorResponse = string.Empty;
            switch (statusCode)
            {
                case 400: errorResponse = "A bad request, you have made"; break;
                case 401: errorResponse = "Authorized, you are not"; break;
                case 404: errorResponse = "Resource found, it was not"; break;
                case 500: errorResponse = "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. hate leads to career change"; break;
                default:
                    errorResponse = null;
                    break;
            };

            return errorResponse;
        }
    }
}
