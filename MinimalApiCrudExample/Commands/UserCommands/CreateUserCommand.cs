﻿namespace MinimalApiCrudExample.Commands.UserCommands;

public class CreateUserCommand : IRequest<UserResponseModel>
{
    public PutUserRequestModel UserRequest { get; }
    
    public CreateUserCommand(PutUserRequestModel userRequest)
    {
        UserRequest = userRequest;
    }
}
