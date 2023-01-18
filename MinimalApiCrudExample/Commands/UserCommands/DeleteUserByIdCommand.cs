namespace MinimalApiCrudExample.Commands.UserCommands;

public class DeleteUserByIdCommand : IRequest<UserResponseModel>
{
    public string UserId { get; }
    public DeleteUserByIdCommand(string id)
    {
        UserId = id;
    }
}
