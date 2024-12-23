using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
    }
}
