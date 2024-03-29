﻿namespace MinimalApiCrudExample.Handlers.UserHandlers;

public class PutUserCommandHandler : IRequestHandler<PutUserCommand, UserResponseModel?>
{
    private readonly UserService _userService;

    public PutUserCommandHandler(UserService userService)
    {
        _userService = userService;
    }

    public async ValueTask<UserResponseModel?> Handle(PutUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.UpdateUser(request.Model.ToUser());
        return user?.ToUserResponse();
        
    }
}
