namespace MinimalApiCrudExample.Commands.UserCommands
{
    public class DeleteUserByIdCommand : IRequest<UserResponse>
    {
        public string UserId { get; }
        public DeleteUserByIdCommand(string id)
        {
            UserId = id;
        }
    }
}
