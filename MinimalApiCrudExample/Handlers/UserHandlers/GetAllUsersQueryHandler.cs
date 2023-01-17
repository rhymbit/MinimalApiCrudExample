namespace MinimalApiCrudExample.Handlers.UserHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserResponse>?>
    {
        private readonly UserService _userService;

        public GetAllUsersQueryHandler(UserService userService)
        {
            _userService = userService;
        }
        public async ValueTask<List<UserResponse>?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _userService.GetAllUsers();
            var allUserResponses = allUsers.Select(u => u.ToUserResponse()).ToList();
            return allUserResponses;
        }
    }
}
