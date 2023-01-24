namespace MinimalApiCrudExample.Services
{
    public class UserCountingService
    {
        private readonly CrudExampleDbContext _db;
        public UserCountingService(CrudExampleDbContext db)
        {
            _db = db;
        }

        public async Task CountUsers(CancellationToken ctoken)
        {
            while(!ctoken.IsCancellationRequested)
            {
                Console.WriteLine($"\nCurrent user count is: {_db.Users.Count()}");
                await Task.Delay(2000, ctoken);
            }
        }
    }
}
