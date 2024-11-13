using CafeMenu.Core.DataAccess;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
