using MediatR;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;

namespace test.Infrastructure.CQRS.Commands.Request.ProductRequest
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {

        public Product Product { get; set; }



    }
}
