namespace MinimalApiCrudExample.Queries.Users;

public class GetUserById : IRequest<UserResponseModel>
{
    public string UserId { get; }

    public GetUserById(string id)
    {
        UserId = id;
    }
}
