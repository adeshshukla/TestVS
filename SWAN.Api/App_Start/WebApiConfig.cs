using SWAN.Filters;
using SWAN.Repository.Interfaces;
using SWAN.Repository.Repository;
using SWAN.Services.Interfaces;
using SWAN.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace SWAN
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();           

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ConfigureDependencies(config);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //AutoMapperConfig.Initialize();

            // Self referencing loop detected for property
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Register Filters.
            config.Filters.Add(new CustomExceptionFilter());
        }

        private static void ConfigureDependencies(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<ISessionRepository, SessionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISessionService, SessionService>(new HierarchicalLifetimeManager());

            container.RegisterType<ISemesterRepository, SemesterRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISemesterService, SemesterService>(new HierarchicalLifetimeManager());

            container.RegisterType<IUniversityRepository, UniversityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUniversityService, UniversityService>(new HierarchicalLifetimeManager());

            //container.RegisterType<ISessionRepository, MockRepo>(new HierarchicalLifetimeManager());


            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
