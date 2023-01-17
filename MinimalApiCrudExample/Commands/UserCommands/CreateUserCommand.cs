namespace MinimalApiCrudExample.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public UserRequest UserRequest { get; }
        
        public CreateUserCommand(UserRequest userRequest)
        {
            UserRequest = userRequest;
        }
    }
}
