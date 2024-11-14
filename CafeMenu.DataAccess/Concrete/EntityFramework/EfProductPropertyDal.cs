using CafeMenu.Core.DataAccess.EntityFramework;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.DataAccess.Concrete.EntityFramework.Contexts;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.DataAccess.Concrete.EntityFramework
{
    public class EfProductPropertyDal : EfEntityRepositoryBase<ProductProperty, CafeMenuContext>, IProductPropertyDal
    {
    }
}
