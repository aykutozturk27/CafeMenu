using Autofac;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Concrete.Managers;
using CafeMenu.Core.Utilities.Security.JWT;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace CafeMenu.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}
