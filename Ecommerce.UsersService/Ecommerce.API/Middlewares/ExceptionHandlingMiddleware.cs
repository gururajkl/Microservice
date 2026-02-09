namespace Ecommerce.API.Middlewares;

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
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
