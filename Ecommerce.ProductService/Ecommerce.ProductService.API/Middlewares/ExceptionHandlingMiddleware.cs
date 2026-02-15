namespace Ecommerce.ProductService.API.Middlewares;

/// <summary>
/// Middleware that handles exceptions thrown during the request processing pipeline, logging the error details and
/// returning a standardized error response.
/// </summary>
/// <remarks>
/// This middleware captures exceptions thrown by downstream middleware, logs the exception type and
/// message, and returns a 500 Internal Server Error response with the exception message and type in JSON
/// format.
/// </remarks>
/// <param name="next">The delegate that represents the next middleware in the request processing pipeline.</param>
/// <param name="logger">The logger used to log error details when an exception occurs.</param>
public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            // Log the exception type and message.
            logger.LogError($"{ex.GetType()}: {ex.Message}");

            if (ex.InnerException is not null)
            {
                // Log the inner exception type and message.
                logger.LogError($"{ex.InnerException.GetType()}: {ex.InnerException.Message}");
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                ex.Message,
                Type = ex.GetType()
            });
        }
    }
}

public static class ExceptionHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
