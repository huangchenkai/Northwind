using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NorthWindDemo.Models;
using NorthWindDemo.Models.BLO;
using NorthWindDemo.Models.DAO;
using NorthWindDemo.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NorthWindDemo
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Base set-up
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            //

            var baseType = typeof(IAutoInject);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                            .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                            .AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired();


            // Register dependencies
            SetUpRegistration(builder);


            // Build registration.
            var container = builder.Build();

            // Set the MVC dependency resolver to be Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Set the WebApi dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        private static void SetUpRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<NorthwindEntities1>().As<DbContext>();
            builder.RegisterType<Catagory_DAO>().As<ICatagory_DAO>();
            builder.RegisterType<Catagory_BLO>().As<ICatagory_BLO>();
        }



    }
}