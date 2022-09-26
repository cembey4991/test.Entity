using MediatR;
using test.Infrastructure.CQRS.Events.Notification;
using test.Infrastructure.Interfaces;

namespace test.Infrastructure.CQRS.Events.Handler
{
    public class ProductHandler : INotificationHandler<ProductInsertNotification>
    {
        private readonly IProductRepository _productRepository;


        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductInsertNotification notification, CancellationToken cancellationToken)
        {
            await _productRepository.EventOccured(notification.product, "try");
            await Task.CompletedTask;
        }
    }
}
