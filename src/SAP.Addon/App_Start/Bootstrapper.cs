﻿using Autofac;
using Autofac.Integration.Mvc;
using SAP.Addon.Domain.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebCore.Domain;
using WebCore.Domain.Interfaces;
using WebCore.Domain.Interfaces.Configuration;
using WebCore.Domain.Repositories.Configuration;
using WebCore.Domain.Services.Configuration;

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
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Initialize Services
            // System

            // Repositories
            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ZUSRService).Assembly).Where(t => t.Name.EndsWith("Service")).InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}