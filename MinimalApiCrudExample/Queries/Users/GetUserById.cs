namespace MinimalApiCrudExample.Queries.Users
{
    public class GetUserById : IRequest<UserResponse>
    {
        public string UserId { get; }

        public GetUserById(string id)
        {
            UserId = id;
        }
    }
}
