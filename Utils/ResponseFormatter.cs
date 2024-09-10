namespace Dotnet_Assessment.Utils
{
    public class ResponseFormatter
    {
        public static object FormatResponse(bool status, int statusCode, object? data, string message)
        {
            return new
            {
                StatusCode = statusCode,
                Status = status,
                Data = data,
                Message = message,
            };
        }
    }
}