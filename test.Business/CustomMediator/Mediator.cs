using ServiceProvider = test.Business.ServiceMediator.ServiceProvider;

namespace test.Business.CustomMediator
{
    public class Mediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var reqType = request.GetType();
            var reqTypeInterface = reqType.GetInterfaces()
                .Where(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IRequest<>))
                .FirstOrDefault();
            var responseType = reqTypeInterface.GetGenericArguments()[0];
            var genericType = typeof(IRequestHandler<,>).MakeGenericType(reqType, responseType);
            var handler = ServiceProvider.ServiceProvicer.GetService(genericType);
            return (Task<TResponse>)genericType.GetMethod("Handle").Invoke(handler, new object[] { request });
        }


    }
}
