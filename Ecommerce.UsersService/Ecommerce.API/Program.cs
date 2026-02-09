using Ecommerce.API.Middlewares;
using Ecommerce.Core;
using Ecommerce.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services.
builder.Services.AddInfrastructure();

// Add core services.
builder.Services.AddCore();

// Add controllers to the services.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Custom exception handler.
app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
