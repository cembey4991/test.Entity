using test.Business.Dtos;
using test.Entity.Entities;

namespace test.Business.Interface
{
    public interface IProductService : IGenericService<Product, ProductDto>
    {

        Task<List<Product>> GetProductMostCheap();
        Task<List<Product>> GetProductMostExpensive();
        //Task<Product> UpdateProduct(UpdateProductCommandRequest request);
        //Task<List<Product>> GetAllProductsAsync();
        //Task<AddProductCommandResponse> InsertProduct(AddProductCommandRequest request);
        //  Task<bool> DeleteProduct(DeleteProductCommandRequest request);
        // Task<Product> GetProductById(string id);

        Task<List<Product>> GetContainsProductName(string productName);

    }
}
