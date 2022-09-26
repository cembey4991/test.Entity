using test.Entity.Entities;

namespace test.Infrastructure.CQRS.Commands.Response.ProductResponse
{
    public class UpdateProductCommandResponse
    {
        public UpdateProductCommandResponse(Product product)
        {

            Product = product;



        }
        public Product Product { get; set; }
        public string Updated { get; set; } = DateTime.Now.ToString("d");
    }
}
