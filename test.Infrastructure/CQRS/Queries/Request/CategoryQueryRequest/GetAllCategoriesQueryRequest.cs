using MediatR;
using test.Infrastructure.CQRS.Queries.Response.CategoryQueryResponse;

namespace test.Infrastructure.CQRS.Queries.Request.CategoryQueryRequest
{
    public class GetAllCategoriesQueryRequest : IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
