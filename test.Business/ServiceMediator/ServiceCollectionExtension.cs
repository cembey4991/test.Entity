using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace test.Business.ServiceMediator
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomMediator(this IServiceCollection services, Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(c => c.GetTypes()).Where(c => !c.IsInterface);
            var requestHandlers = types
                .Where(i => IsAssignableToGenericType(i, typeof(IRequestHandler<,>)))
                .ToList();
            foreach (var handler in requestHandlers)
            {
                var handlerInterface = handler.GetInterfaces().FirstOrDefault();
                var requestType = handlerInterface.GetGenericArguments()[0];
                var responseType = handlerInterface.GetGenericArguments()[1];
                var genericType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
                services.AddTransient(genericType, handler);
            }
            services.AddSingleton<IMediator, Mediator>();
            return services;
        }
        public static IServiceProvider UseCustomMediator(this IServiceProvider serviceProvider)
        {
            ServiceProvider.SetInstance(serviceProvider);
            return serviceProvider;
        }
        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            bool IsGeneric(Type _givenType, Type _genericType)
            {
                return _givenType.IsGenericType && _givenType.GetGenericTypeDefinition() == genericType;
            }
            var interfaceTypes = givenType.GetInterfaces();
            foreach (var item in interfaceTypes)
            {
                if (IsGeneric(item, genericType))
                    return true;
            }
            if (IsGeneric(givenType, genericType))
                return true;
            Type baseType = givenType.BaseType;
            if (baseType == null)
                return false;
            return IsAssignableToGenericType(baseType, genericType);

        }
    }
}
