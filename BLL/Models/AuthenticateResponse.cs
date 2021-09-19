using Entities;

namespace BLL.Models
{
    public class AuthenticateResponse
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            ID = user.ID;
            Username = user.Username;
            Token = token;
        }
    }
}