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
builder.Services.AddScoped<IValidator<PutUserRequestModel>, AddUserValidator>();
builder.Services.AddScoped<IValidator<PutUserRequestModel>, PutUserValidator>();
// Mediator
builder.Services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
// Custom Services
builder.Services.AddScoped<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapUserEndponts();

app.Run();