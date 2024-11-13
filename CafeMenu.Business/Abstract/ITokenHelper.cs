using CafeMenu.Core.Utilities.Security.JWT;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.Business.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
