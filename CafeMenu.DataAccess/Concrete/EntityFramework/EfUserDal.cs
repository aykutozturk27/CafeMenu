using CafeMenu.Core.DataAccess.EntityFramework;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.DataAccess.Concrete.EntityFramework.Contexts;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CafeMenuContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CafeMenuContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
