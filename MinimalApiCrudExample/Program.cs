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
// Db Service
builder.Services.AddDbContext<CrudExampleDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});
// Fluent Validation
builder.Services.AddScoped<IValidator<AddUserRequestModel>, AddUserValidator>();
builder.Services.AddScoped<IValidator<PutUserRequestModel>, PutUserValidator>();
// Mediator
builder.Services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
// Custom Services
builder.Services.AddScoped<UserService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Custom Middleware
app.UseMiddleware<OperationCancelledMiddleware>();

app.MapGroup("/api/users")
    .MapUserEndpoints();

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        Welcome = "Welcome to the simple User CRUD API",
        Endpoints = new
        {
            GET = "GET: /api/users, returns all users",
            GET2 = "GET: /api/users/{id}, returns user with {id}",
            POST = "POST: /api/users, adds a new user to db",
            PUT = "PUT: /api/users, updates an existing user in db",
            DELETE = "DELETE: /api/users/{id}, deletes the user from the db with {id}",
            DELETE2 = "DELETE: /api/users, deletes all users from the db"
        }
    });
})
    .WithName("Home");


app.Run();