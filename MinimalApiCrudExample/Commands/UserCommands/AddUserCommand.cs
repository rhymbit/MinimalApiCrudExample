namespace MinimalApiCrudExample.Commands.UserCommands;

public class AddUserCommand : IRequest<UserResponseModel>
{
    public AddUserRequestModel Model { get; }
    
    public AddUserCommand(AddUserRequestModel model)
    {
        Model = model;
    }
}
