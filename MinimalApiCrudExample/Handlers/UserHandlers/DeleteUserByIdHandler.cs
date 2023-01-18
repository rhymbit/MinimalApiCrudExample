namespace MinimalApiCrudExample.Handlers.UserHandlers;

public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand, UserResponseModel?>
{
    private readonly UserService _userService;

    public DeleteUserByIdHandler(UserService userService)
    {
        _userService = userService;
    }

    public async ValueTask<UserResponseModel?> Handle(DeleteUserByIdCommand request, CancellationToken ctoken)
    {
        var user = await _userService.DeleteUser(request.UserId);
        return user?.ToUserResponse();
    }
}
