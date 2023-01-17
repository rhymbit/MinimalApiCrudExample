using CrudExampleDatabase;
using CrudExampleDatabase.Models;
using Microsoft.EntityFrameworkCore;
using MinimalApiCrudExample.Endpoints;
using MinimalApiCrudExample.Services;

var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.Combine(
    $"..{Path.DirectorySeparatorChar}",
    "CrudExampleDatabase",
    "database.db"
);

using (var db = new CrudExampleDbContext())
{
    db.Database.Migrate();
}


// Add services to the container.
builder.Services.AddDbContext<CrudExampleDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});


builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapUserEndponts();

app.MapGet("/allUsers", (CrudExampleDbContext db) =>
{
    var users = db.Users;
    return Results.Ok(users);
});

app.MapGet("/addTestUser", (CrudExampleDbContext db) =>
{
    var testUser = new User
    {
        Id = Guid.NewGuid().ToString(),
        Name = "John",
        Age = 23,
        Email = "john@mail.com",
        Password = "JohnPassword"
    };
    db.Users?.Add(testUser);
    db.SaveChanges();
    return Results.Ok(testUser);
});

app.Run();