using MediatR;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;

namespace test.Infrastructure.CQRS.Commands.Request.ProductRequest
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
