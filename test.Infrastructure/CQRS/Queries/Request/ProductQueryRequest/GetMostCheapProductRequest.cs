using MediatR;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;

namespace test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest
{
    public class GetMostCheapProductRequest : IRequest<GetMostCheapProductResponse>
    {
        public Product Product { get; set; }

    }
}
