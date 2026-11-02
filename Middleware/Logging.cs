namespace UserApi.Middleware;

public class Logging
{
    private readonly RequestDelegate _next;
    private readonly ILogger<Logging> _logger;

    public Logging(
        RequestDelegate next,
        ILogger<Logging> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestPath = context.Request.Path;
        var method = context.Request.Method;

        await _next(context);

        var statusCode = context.Response.StatusCode;

        _logger.LogInformation(
            "Method: {Method} | Path: {Path} | StatusCode: {StatusCode}",
            method,
            requestPath,
            statusCode);
    }
}