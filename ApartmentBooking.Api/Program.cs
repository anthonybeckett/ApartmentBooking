using ApartmentBooking.Api.Extensions;
using ApartmentBooking.Application;
using ApartmentBooking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.ApplyMigrations();

    //Only run this when we need some sample data
    // app.SeedData();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
