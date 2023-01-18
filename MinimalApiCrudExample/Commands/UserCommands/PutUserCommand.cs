namespace MinimalApiCrudExample.Commands.UserCommands;

public class PutUserCommand : IRequest<UserResponseModel>
{
    public PutUserRequestModel UserRequest { get; }

    public PutUserCommand(PutUserRequestModel userRequest)
    {
        UserRequest = userRequest;
    }
}
