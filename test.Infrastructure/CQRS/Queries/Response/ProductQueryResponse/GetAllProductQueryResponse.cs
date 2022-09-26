using test.Entity.Entities;

namespace test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse
{
    public class GetAllProductQueryResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
