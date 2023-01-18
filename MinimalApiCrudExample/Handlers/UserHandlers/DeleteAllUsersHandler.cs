namespace MinimalApiCrudExample.Handlers.UserHandlers;

public class DeleteAllUsersHandler : IRequestHandler<DeleteAllUsersCommand, List<UserResponseModel>?>
{
    private readonly UserService _userService;

    public DeleteAllUsersHandler(UserService userService)
    {
        _userService = userService;
    }
    public async ValueTask<List<UserResponseModel>?> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await _userService.DeleteAllUsers();
        return users?.Select(u => u.ToUserResponse()).ToList();
    }
}
