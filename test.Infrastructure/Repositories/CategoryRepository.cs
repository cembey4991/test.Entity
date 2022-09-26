using MongoDB.Driver;
using MongoDB.Driver.Linq;
using test.Entity.Entities;
using test.Infrastructure.Interfaces;
using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IMongoCollection<Product> _mongoCollection;

        public CategoryRepository(IProductDatabase settings) : base(settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _mongoCollection = database.GetCollection<Product>(typeof(Product).Name);


        }

        public async Task<List<Product>> GetCategoryByIdToProducts(string id)
        {
            IMongoQueryable<Product> results = (IMongoQueryable<Product>)(from product in _mongoCollection.AsQueryable()
                                                                          where product.CategoryId == id
                                                                          select product);
            return results.ToList();

        }
    }
}
