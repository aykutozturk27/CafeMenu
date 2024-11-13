using CafeMenu.Core.DataAccess;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
