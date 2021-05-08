namespace NoorsoftHomework.Web.Resources.Shared
{
    public record ApiResponse(int Status, bool Success, object? Data, string? ErrorMessage)
    {
        public static ApiResponse Successful(int status, object data)
        {
            const bool    success      = true;
            const string? errorMessage = null;
            return new(status, success, data, errorMessage);
        }

        public static ApiResponse Error(int status, string errorMessage)
        {
            const bool    success = false;
            const object? data    = null;
            return new(status, success, data, errorMessage);
        }
    }
}