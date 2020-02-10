using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using UnitTest.Web.Domain;
using UnitTest.Web.Repository;
using UnitTest.Web.Service;

namespace UnitTest.Web.App_Start
{
    public class DependencyConfig
    {
        public static IContainer _Container;
        public static IContainer SetAutofacWebAPI()
        {

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterGeneric(typeof(RepositoryBase<>))
            //    .As(typeof(IRepositoryBase<>));



            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerDependency();

            //builder.RegisterAssemblyTypes(typeof(LogUtilities).Assembly)
            //    .Where(t => t.Name.EndsWith("Utilities"))
            //    .AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerDependency();
 
            builder.RegisterType<DataContext>().InstancePerDependency();

            var container = builder.Build();

         
            GlobalConfiguration.Configuration.DependencyResolver = new Autofac.Integration.WebApi.AutofacWebApiDependencyResolver(container);
            _Container = container;
            return container;


        }

    }
}