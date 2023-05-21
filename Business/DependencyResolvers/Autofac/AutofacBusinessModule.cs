using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module

    {

        protected override void Load(ContainerBuilder builder)
        {
            // SingleInstance tek bir instance oluşturur ve onu herkese verir
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            // assemblydeki tüm classları bul

            builder .RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    // AutofacInterceptorSelector classını çalıştır
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            
        }

    }
}
