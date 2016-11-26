using Autofac;
using Autofac.Integration.Mvc;
using SAP.Addon.Domain.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SAP.Addon.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Initialize Services
            // System

            builder.RegisterAssemblyTypes(typeof(ZUSRService).Assembly).Where(t => t.Name.EndsWith("Service")).InstancePerHttpRequest();


            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}