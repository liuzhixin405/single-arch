using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.DependencyInjection
{
     public static class Extensions
    {
        public static void ReisterServiceFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var typesWithServiceAttribute = assembly.GetTypes().Where(t => t.GetCustomAttributes<DepAttribute>().Any());

            foreach (var type in typesWithServiceAttribute)
            {
                var servceAttribute = type.GetCustomAttribute<DepAttribute>();
                services.Add(new ServiceDescriptor(servceAttribute.ServiceType ?? type, type, servceAttribute.Lifetime));
            }
        }
    }
}
