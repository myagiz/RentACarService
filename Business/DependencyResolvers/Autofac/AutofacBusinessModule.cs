using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();

            // DAL
            builder.RegisterType<EfCoreBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCoreCarDal>().As<ICarDal>();
            builder.RegisterType<EfCoreColorDal>().As<IColorDal>();
            builder.RegisterType<EfCoreCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfCoreRentalDal>().As<IRentalDal>();
            builder.RegisterType<EfCoreUserDal>().As<IUserDal>();
            builder.RegisterType<EfCoreImageDal>().As<ICarImageDal>();


            //ValidationAOP
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
