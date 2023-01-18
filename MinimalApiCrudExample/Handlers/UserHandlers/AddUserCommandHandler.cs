namespace MinimalApiCrudExample.Handlers.UserHandlers;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserResponseModel?>
{
    private readonly UserService _userService;

    public AddUserCommandHandler(UserService userService)
    {
        _userService = userService;
    }
    public async ValueTask<UserResponseModel?> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.AddUser(request.Model.ToUser());
        return user?.ToUserResponse();
    }
}
