using test.Business.Dtos;
using test.Entity.Entities;

namespace test.Business.Interface
{
    public interface ICategoryService : IGenericService<Category, CategoryDto>
    {

        Task<List<Product>> GetCategoryByIdToProducts(string id);

    }
}
