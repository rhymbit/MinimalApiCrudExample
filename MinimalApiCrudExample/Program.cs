using MinimalApiCrudExample.Endpoints;
using MinimalApiCrudExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapUserEndponts();

app.Run();