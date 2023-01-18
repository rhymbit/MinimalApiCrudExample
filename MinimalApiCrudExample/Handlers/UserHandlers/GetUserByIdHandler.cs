namespace MinimalApiCrudExample.Handlers.UserHandlers;

public class GetUserByIdHandler : IRequestHandler<GetUserById, UserResponseModel?>
{
    private readonly UserService _userService;

    public GetUserByIdHandler(UserService userService)
    {
        _userService = userService;
    }
    public async ValueTask<UserResponseModel?> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUser(request.UserId);
        return user?.ToUserResponse();
    }
}
