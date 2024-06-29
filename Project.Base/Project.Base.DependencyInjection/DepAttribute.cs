using Microsoft.Extensions.DependencyInjection;

namespace Project.Base.DependencyInjection
{
    /// <summary>
    /// 最最简单的特性注入
    /// </summary>
   
   [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class DepAttribute : Attribute
    {
        public DepAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Lifetime = lifetime;
        }
        public DepAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }
        public Type ServiceType { get; }
        public ServiceLifetime Lifetime { get; }
    }
}
