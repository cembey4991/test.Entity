using MediatR;
using test.Entity.Entities;

namespace test.Infrastructure.CQRS.Events.Notification
{
    public record ProductInsertNotification(Product product) : INotification
    {
    }
}
