namespace MinimalApiCrudExample.Handlers.UserHandlers
{
    public class AddUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse?>
    {
        private readonly UserService _userService;

        public AddUserCommandHandler(UserService userService)
        {
            _userService = userService;
        }
        public async ValueTask<UserResponse?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.AddUser(request.UserRequest.ToUser());
            return user?.ToUserResponse();
        }
    }
}
