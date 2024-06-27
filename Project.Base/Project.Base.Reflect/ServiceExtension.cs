using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Reflect
{
    public static class ServiceExtension
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "bus_lib");

            var dllFiles = Directory.GetFiles(folder, "*.Business.dll");

            var assemblies = dllFiles.Select(Assembly.LoadFrom).ToArray();

            var businessTypes = assemblies.SelectMany(a => a.GetTypes().Where(t => t.IsClass&&!t.IsAbstract)).Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBusiness<>))).ToList();
            CastleInterceptor castleInterceptor = new CastleInterceptor();

            foreach (var type in businessTypes)
            {
                var interfaceType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBusiness<>));
                services.AddTransient(interfaceType, provider =>
                {
                    var target = ActivatorUtilities.CreateInstance(provider, type);
                    return _generator.CreateInterfaceProxyWithTarget(interfaceType, target, castleInterceptor);
                });
            }

            return services;
        }
    }
}
