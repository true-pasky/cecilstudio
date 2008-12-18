using System;
using System.Collections.Generic;

namespace Cecil.Decompiler.Gui.Services
{
    internal class ServiceProvider : IServiceProvider 
    {
        private readonly Dictionary<Type, IService> services = new Dictionary<Type, IService>();
        private static readonly ServiceProvider instance;

        public static ServiceProvider GetInstance()
        {
            return instance;
        }

        static ServiceProvider()
        {
            instance = new ServiceProvider();
        }

        private ServiceProvider()
        {
        }

        public object GetService(Type serviceType)
        {
            if (services.ContainsKey(serviceType))
            {
                return services[serviceType];
            }
            throw new ArgumentException(serviceType.Name + " is not registered");
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public void RegisterService(Type serviceType, IService service)
        {
            services.Add(serviceType, service);
        }

        public void UnRegisterService(Type serviceType)
        {
            services.Remove(serviceType);
        }

    }
}
