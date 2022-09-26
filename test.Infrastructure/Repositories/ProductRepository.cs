using MongoDB.Driver;
using MongoDB.Driver.Linq;
using test.Entity.Entities;
using test.Infrastructure.Interfaces;
using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        // List<Product> _products;
        public ProductRepository(IProductDatabase settings) : base(settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>(typeof(Product).Name);


            //var client = new MongoClient(settings.ConnectionString);
            //var database = client.GetDatabase(settings.DatabaseName);
            //_mongoProducts = database.GetCollection<MongoProduct>(settings.ProductCollectionName);
            //_products = new List<Product>
            //{
            //    new Product {Id=1, Name="Ürün",CategoryId=1, Price=500 },
            //    new Product {Id=2, Name="Ürün 1",CategoryId=1, Price=500},
            //    new Product {Id=3, Name="Ürün 2 ",CategoryId=2, Price=500},
            //    new Product {Id=4, Name="Ürün 2 ",CategoryId=2, Price=1000},
            //    new Product {Id=5, Name="Ürün 2 ",CategoryId=2, Price=1500},
            //    new Product {Id=6, Name="Ürün 2 ",CategoryId=2, Price=2500},
            //};

        }


        public async Task EventOccured(Product product, string evt)
        {
            _collection.Find(c => c.Id == product.Id);
            await Task.CompletedTask;
        }

        public async Task<List<Product>> GetProductMostExpensive()
        {
            IMongoQueryable<Product> query = (IMongoQueryable<Product>)(from product in _collection.AsQueryable()
                                                                        orderby product.Price descending
                                                                        select product);
            //var result = _mongoCollection.AsQueryable().OrderByDescending(c => c.Price).FirstOrDefault();
            return query.ToList();
        }

        public async Task<List<Product>> GetProductMostCheap()
        {
            var result = _collection.AsQueryable().OrderBy(c => c.Price).ToList();
            return result;
        }

        public async Task<List<Product>> GetContainsProductName(string productName)
        {
            //IMongoQueryable<Product> query = (IMongoQueryable<Product>)(from product in _mongoCollection.AsQueryable()
            //                                                            where product.Name.ToLower().Contains(productName.ToLower())
            //                                                              select product);

            //return query.ToList();

            //or

            var query = _collection.AsQueryable().Where(c => c.Name.ToLower().Contains(productName.ToLower()));
            return query.ToList();

        }

    }
}
