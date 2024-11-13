using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
    }
}
