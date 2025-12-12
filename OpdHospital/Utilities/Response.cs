namespace OpdHospital.Utilities
{
    public static class Response
    {
        public static object Success(object? data = null, string message = "Success", int count = 0)
        {
            return new ApiResponse
            {
                Success = true,
                Message = message,
                Data = data,
                TotalRecords =  count,
            };
        }

        public static object Fail(string message, object? data = null)
        {
            return new ApiResponse
            {
                Success = false,
                Message = message,
                Data = data
            };
        }

        public static object Exception(Exception ex)
        {
            return new ApiResponse
            {
                Success = false,
                Message = ex.Message,      // Or ex.ToString() if you want stack trace
                Data = null
            };
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
        public int TotalRecords { get; set; }  = 0;
    }
}
