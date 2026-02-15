using Ecommerce.ProductService.API.Middlewares;
using Ecommerce.ProductService.Core;
using Ecommerce.ProductService.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services of core and infrastructure project.
builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();

// Fluent validation.
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
