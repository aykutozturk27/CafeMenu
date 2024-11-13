using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Core.Utilities.Security.JWT;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
