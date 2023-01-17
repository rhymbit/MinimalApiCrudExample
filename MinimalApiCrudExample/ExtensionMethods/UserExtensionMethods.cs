namespace MinimalApiCrudExample.ExtensionMethods
{
    public static class UserExtensionMethods
    {
        public static User ToUser(this UserRequest userRequest)
        {
            return new()
            {
                Id = userRequest.Id,
                Name = userRequest.Name ?? "",
                Age = userRequest.Age,
                Email = userRequest.Email ?? "",
                Password = userRequest.Password ?? ""
            };
        }

        public static UserResponse ToUserResponse(this User user)
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
}
