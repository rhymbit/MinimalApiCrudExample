namespace MinimalApiCrudExample.Models.UserModel
{
    public class UserRequest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public UInt16 Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
