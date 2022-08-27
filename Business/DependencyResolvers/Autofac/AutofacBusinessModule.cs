using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<ProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<ShippingCompanyManager>().As<IShippingCompanyService>().SingleInstance();
            builder.RegisterType<ShippingCompanyDal>().As<IShippingCompanyDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>().SingleInstance();
        }
    }
}