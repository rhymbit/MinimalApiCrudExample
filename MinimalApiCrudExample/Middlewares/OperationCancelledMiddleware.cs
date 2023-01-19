namespace MinimalApiCrudExample.Middlewares;

public class OperationCancelledMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public OperationCancelledMiddleware(RequestDelegate next, ILogger<OperationCancelledMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Request was cancelled");
        }
    }
}
