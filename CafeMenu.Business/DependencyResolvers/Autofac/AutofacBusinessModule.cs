using Autofac;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Concrete.Managers;
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

            builder.RegisterType<PropertyManager>().As<IPropertyService>();
            builder.RegisterType<EfPropertyDal>().As<IPropertyDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}
