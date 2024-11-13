using CafeMenu.Entities.Concrete;

namespace CafeMenu.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByUsername(string userName);
    }
}
