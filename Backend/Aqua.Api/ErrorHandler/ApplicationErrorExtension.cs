namespace com.marcelbenders.Aqua.Api.ErrorHandler;

public static class ApplicationErrorExtension
{
    public static void AddApplicationError(this HttpResponse response, string message)
    {
        response.Headers.Add("Application-Error", message);
        response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
        response.Headers.Add("Access-Control-Allow-Origin", "*");
    }
}