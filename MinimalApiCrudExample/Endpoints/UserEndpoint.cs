using CrudExampleDatabase.Models;
using MinimalApiCrudExample.Services;

namespace MinimalApiCrudExample.Endpoints;

public static class UserEndpoint
{
    public static void MapUserEndponts(this WebApplication app)
    {
        app.MapGet("/users", GetAllUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPost("/users", CreateUser);
        app.MapPut("/users", UpdateUser);
        app.MapDelete("/users/{id}", DeleteUser);
        app.MapDelete("/users", DeleteAllUsers);
    }

    public static async Task<IResult> GetAllUsers(UserService userService)
    {
        var allUsers = await userService.GetAllUsers();
        return Results.Ok(allUsers);
    }

    public static async Task<IResult> GetUser(string id, UserService userService)
    {
        var user = await userService.GetUser(id);
        if (user is null)
        {
            return Results.NotFound(id);
        }
        return Results.Ok(user);
    }
    
    public static async Task<IResult> CreateUser(User user, UserService userService)
    {
        var newUser = await userService.AddUser(user);
        return Results.Created($"/users/{user.Id}", newUser);
    }

    public static async Task<IResult> UpdateUser(User user, UserService userService)
    {
        var existingUser = await userService.UpdateUser(user);
        if (existingUser is null)
        {
            return Results.NotFound(user.Id);
        }
        return Results.Accepted();
    }

    public static async Task<IResult> DeleteUser(string id, UserService userService)
    {
        var existingUser = await userService.DeleteUser(id);
        if (existingUser is null)
        {
            return Results.NotFound(id);

        }
        return Results.NoContent();
    }

    public static async Task<IResult> DeleteAllUsers(UserService userService)
    {
        await userService.DeleteAllUsers();
        return Results.NoContent();
    }
}

