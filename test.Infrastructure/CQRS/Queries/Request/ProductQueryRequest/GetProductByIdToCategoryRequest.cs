using MediatR;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;

namespace test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest
{
    public class GetProductByIdToCategoryRequest : IRequest<GetProductByIdToCategoryResponse>
    {
        public string ProductId { get; set; }
    }
}
