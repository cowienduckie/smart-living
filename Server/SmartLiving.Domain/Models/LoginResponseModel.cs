using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Models
{
    public class LoginResponseModel
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public string Token { get; }


        public LoginResponseModel(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.UserName;
            Token = token;
        }
    }
}