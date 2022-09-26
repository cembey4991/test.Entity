using test.Entity.Entities;

namespace test.Infrastructure.CQRS.Commands.Response.ProductResponse
{
    public class CommandResponse
    {
        public CommandResponse(Product product)
        {
            Product = product;
        }

        public Product Product { get; set; }
    }
}
