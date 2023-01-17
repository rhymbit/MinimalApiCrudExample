namespace MinimalApiCrudExample.Handlers.UserHandlers
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, UserResponse?>
    {
        private readonly UserService _userService;

        public PutUserCommandHandler(UserService userService)
        {
            _userService = userService;
        }

        public async ValueTask<UserResponse?> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.UpdateUser(request.UserRequest.ToUser());
            return user?.ToUserResponse();
            
        }
    }
}
