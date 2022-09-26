using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Text;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Commands.Request.ProductRequest;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;
using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.CQRS.Handler.CommandsHandlers.ProductHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>, INotification
    {

        private readonly IDistributedCache _distributedCache;
        private readonly IMongoCollection<Product> _collection;
        public AddProductCommandHandler(IDistributedCache distributedCache, IProductDatabase settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>(typeof(Product).Name);
            _distributedCache = distributedCache;


        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = "addProduct";
            var addProduct = _collection.InsertOneAsync(request.Product);
            //var addProductConvert = JsonConvert.SerializeObject(addProduct);
            //var addProductByte = Encoding.UTF8.GetBytes(addProductConvert);
            //await _distributedCache.SetAsync(cacheKey, addProductByte);
            return new AddProductCommandResponse(request.Product);





        }
    }
}
