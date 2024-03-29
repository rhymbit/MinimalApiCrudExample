﻿namespace MinimalApiCrudExample.Endpoints;

public static class UserEndpoint
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllUsers).WithName("GetAllUsers");
        group.MapGet("/{id}", GetUser).WithName("GetUserById");
        group.MapPost("/", AddUser).AddEndpointFilter<AddUserValidatorFilter>().WithName("AddUser");
        group.MapPut("/", PutUser).AddEndpointFilter<PutUserValidatorFilter>().WithName("PutUser");
        group.MapDelete("/{id}", DeleteUser).WithName("DeleteUserById");
        group.MapDelete("/", DeleteAllUsers).WithName("DeleteAllUsers");

        return group;
    }

    public static async Task<IResult> GetAllUsers(IMediator _mediator, CancellationToken ctoken)
    {
        var query = new GetAllUsersQuery();
        var result = await _mediator.Send(query, ctoken);
        await Task.Delay(10_000, ctoken);
        return result != null ? Results.Ok(result) : Results.Ok(new());
    }

    public static async Task<IResult> GetUser(string id, IMediator _mediator, CancellationToken ctoken)
    {
        var query = new GetUserById(id);
        var result = await _mediator.Send(query, ctoken);
        return result != null ? Results.Ok(result) : Results.NotFound();
    }

    public static async Task<IResult> AddUser(AddUserRequestModel user, IMediator _mediator, CancellationToken ctoken)
    {
        var command = new AddUserCommand(user);
        var results = await _mediator.Send(command, ctoken);
        return results != null ? Results.Created($"/users/{results.Id}", results) : Results.Problem();
    }

    public static async Task<IResult> PutUser(PutUserRequestModel user, IMediator _mediator, CancellationToken ctoken)
    {
        var command = new PutUserCommand(user);
        var results = await _mediator.Send(command, ctoken);
        return results != null ? Results.Ok(results) : Results.Problem();
    }

    public static async Task<IResult> DeleteUser(string id, IMediator _mediator, CancellationToken ctoken)
    {
        var command = new DeleteUserByIdCommand(id);
        var results = await _mediator.Send(command, ctoken);
        return results != null ? Results.NoContent() : Results.Problem();
    }

    public static async Task<IResult> DeleteAllUsers(IMediator _mediator, CancellationToken ctoken)
    {
        var command = new DeleteAllUsersCommand();
        var results = await _mediator.Send(command, ctoken);
        return results != null ? Results.NoContent() : Results.Problem();
    }
}

