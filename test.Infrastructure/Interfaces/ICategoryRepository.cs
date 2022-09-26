using test.Entity.Entities;


namespace test.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {

        Task<List<Product>> GetCategoryByIdToProducts(string id);

    }
}
