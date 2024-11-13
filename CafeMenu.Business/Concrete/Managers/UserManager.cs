using CafeMenu.Business.Abstract;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByUsername(string userName)
        {
            return _userDal.Get(u => u.Username == userName);
        }
    }
}
