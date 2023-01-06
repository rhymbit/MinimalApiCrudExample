using MinimalApiCrudExample.Models;
using MinimalApiCrudExample.Services;

namespace MinimalApiCrudExample.Endpoints;

public static class UserEndpoint
{
    public static void MapUserEndponts(this WebApplication app)
    {
        app.MapGet("/users", GetAllUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPost("/users/create", CreateUser);
        app.MapPut("/users/update", UpdateUser);
        app.MapDelete("/users/{id}", DeleteUser);
    }

    public static IResult GetAllUsers(UserService userService)
    {
        return Results.Ok(userService.GetAllUsers());
    }

    public static IResult GetUser(string userId, UserService userService)
    {
        var user = userService.GetUser(userId);
        if (user is null)
        {
            return Results.NotFound(userId);
        }
        return Results.Ok(user);
    }

    public static IResult CreateUser(User user, UserService userService)
    {
        return Results.Created($"/users/{user.Id}", userService.AddUser(user));
    }

    public static IResult UpdateUser(User user, UserService userService)
    {
        var existingUser = userService.UpdateUser(user);
        if (existingUser is null)
        {
            return Results.NotFound(user.Id);
        }
        return Results.Accepted();
    }

    public static IResult DeleteUser(UserService userService, string id)
    {
        var existingUser = userService.DeleteUser(id);
        if (existingUser is null)
        {
            return Results.NotFound(id);

        }
        return Results.NoContent();
    }
}

