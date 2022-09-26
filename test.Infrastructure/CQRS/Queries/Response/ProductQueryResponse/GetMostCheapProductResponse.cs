using test.Entity.Entities;

namespace test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse
{
    public class GetMostCheapProductResponse
    {
        public GetMostCheapProductResponse(Product product)
        {
            Product = product;
        }

        public Product Product { get; set; }
        //public string ProductName { get; set; }

    }
}
