using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace NorthWindDemo
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Base set-up
            var builder = new ContainerBuilder();

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
            //SetUpRegistration(builder);


            // Build registration.
            var container = builder.Build();

            // Set the dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        //private static void SetUpRegistration(ContainerBuilder builder)
        //{
        //    string As400 = ConfigurationManager.ConnectionStrings["As400"].ToString();
        //    string Oracle = ConfigurationManager.ConnectionStrings["OracleDbContext"].ToString();


        //    builder.Register(x => new iDB2Connection(As400))
        //           .As<iDB2Connection>()
        //           .InstancePerLifetimeScope();

        //    builder.Register(x => new OracleConnection(Oracle))
        //          .As<OracleConnection>()
        //          .InstancePerLifetimeScope();

        //    builder.RegisterType<Entities>().As<DbContext>().InstancePerRequest();



        //}



    }
}