using test.Entity.Entities;


namespace test.Infrastructure.CQRS.Commands.Response.ProductResponse
{
    public class AddProductCommandResponse
    {
        public AddProductCommandResponse(Product product)
        {
            Product = product;


        }
        public Product Product { get; set; }

        public string Created { get; set; } = DateTime.Now.ToString("d");
    }
}
