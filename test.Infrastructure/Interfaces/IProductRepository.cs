using test.Entity.Entities;

namespace test.Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        Task<List<Product>> GetProductMostCheap();
        Task<List<Product>> GetProductMostExpensive();
        //Task<List<Product>> GetAllProductsAsync();
        // Task<bool> InsertProduct(AddProductCommandRequest request);
        //Task<Product> UpdateProduct(UpdateProductCommandRequest request);
        //   Task<bool> DeleteProduct(string id);
        // Task<Product> GetProductById(string id);
        Task EventOccured(Product product, string evt);
        Task<List<Product>> GetContainsProductName(string productName);


    }
}
