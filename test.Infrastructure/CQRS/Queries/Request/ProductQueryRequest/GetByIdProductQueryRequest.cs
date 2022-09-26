using MediatR;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;

namespace test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string ProductId { get; set; }
    }
}
