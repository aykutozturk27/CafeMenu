using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
