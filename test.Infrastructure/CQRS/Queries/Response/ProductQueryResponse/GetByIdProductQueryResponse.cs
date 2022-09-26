using test.Entity.Entities;

namespace test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse
{
    public class GetByIdProductQueryResponse
    {
        public GetByIdProductQueryResponse(Product product)
        {
            Product = product;

        }

        public Product Product { get; set; }

    }
}
