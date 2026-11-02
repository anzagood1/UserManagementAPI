using System.Text.Json;

namespace UserApi.Middleware;

public class Authentication
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public Authentication(
        RequestDelegate next,
        IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization
            .FirstOrDefault();

        if (string.IsNullOrEmpty(authHeader) ||
            !authHeader.StartsWith("Bearer "))
        {
            await Unauthorized(context);
            return;
        }

        var token = authHeader["Bearer ".Length..].Trim();

        var validToken =
            _configuration["Authentication:ApiToken"];

        if (token != validToken)
        {
            await Unauthorized(context);
            return;
        }

        await _next(context);
    }

    private static async Task Unauthorized(
        HttpContext context)
    {
        context.Response.StatusCode =
            StatusCodes.Status401Unauthorized;

        context.Response.ContentType =
            "application/json";

        var response = new
        {
            error = "Unauthorized."
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}