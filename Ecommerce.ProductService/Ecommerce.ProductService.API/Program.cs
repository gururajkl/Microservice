using Ecommerce.ProductService.API.APIEndpoints;
using Ecommerce.ProductService.API.Middlewares;
using Ecommerce.ProductService.Core;
using Ecommerce.ProductService.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services of core and infrastructure project.
builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

// Fluent validation.
builder.Services.AddFluentValidationAutoValidation();

// Add String JSON conversion for model binding.
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add swagger services.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors services.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Use swagger.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// Usw cors.
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductEndpoints();

app.Run();
