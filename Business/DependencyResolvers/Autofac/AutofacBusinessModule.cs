using Autofac;
using Business.Abstract;
using Business.Concrete;
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
            // Startup.cs deki services.AddSingleton<IProductService,ProductManager>(); kodu ile aynı işi yapıyor
            // SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
            // Autofac deki SingleInstance tek bir instance oluşturur ve onu herkese verir
            // Autofac deki SingleInstance ile Microsoftun SingleInstance farklıdır
        }

    }
}
