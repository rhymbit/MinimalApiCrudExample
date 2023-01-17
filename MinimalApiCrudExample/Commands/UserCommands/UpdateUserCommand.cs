namespace MinimalApiCrudExample.Commands.UserCommands
{
    public class PutUserCommand : IRequest<UserResponse>
    {
        public UserRequest UserRequest { get; }

        public PutUserCommand(UserRequest userRequest)
        {
            UserRequest = userRequest;
        }
    }
}
