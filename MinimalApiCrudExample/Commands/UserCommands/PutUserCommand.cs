namespace MinimalApiCrudExample.Commands.UserCommands;

public class PutUserCommand : IRequest<UserResponseModel>
{
    public PutUserRequestModel Model { get; }

    public PutUserCommand(PutUserRequestModel model)
    {
        Model = model;
    }
}
