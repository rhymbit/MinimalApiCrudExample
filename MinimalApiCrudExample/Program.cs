
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
builder.Services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapUserEndponts();

app.Run();