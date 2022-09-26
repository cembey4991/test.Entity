using MediatR;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;

namespace test.Infrastructure.CQRS.Commands.Request.ProductRequest
{
    public class CommandRequest : IRequest<CommandResponse>
    {
        public Product Product { get; set; }
    }
}
