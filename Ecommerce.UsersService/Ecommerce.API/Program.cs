using Ecommerce.API.Middlewares;
using Ecommerce.Core;
using Ecommerce.Core.Mappers;
using Ecommerce.Infrastructure;
using FluentValidation.AspNetCore;
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

// Configure auto mapper.
builder.Services.AddAutoMapper(config => { }, typeof(ApplicationUserMappingProfile).Assembly);

// Configure Fluent validation.
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Custom exception handler.
app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
