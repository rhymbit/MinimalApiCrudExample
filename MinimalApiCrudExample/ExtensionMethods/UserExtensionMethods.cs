namespace MinimalApiCrudExample.ExtensionMethods;

public static class UserExtensionMethods
{
    public static User ToUser(this PutUserRequestModel userRequest)
    {
        return new()
        {
            Name = userRequest.Name ?? "",
            Age = userRequest.Age,
            Email = userRequest.Email ?? "",
            Password = userRequest.Password ?? ""
        };
    }

    public static UserResponseModel ToUserResponse(this User user)
    {
        return new()
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            Email = user.Email
        };
    }
}
