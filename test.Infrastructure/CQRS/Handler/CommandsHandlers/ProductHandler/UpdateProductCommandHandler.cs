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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {

        private readonly IMongoCollection<Product> _collection;
        private readonly IDistributedCache _distributedCache;
        public UpdateProductCommandHandler(IDistributedCache distributedCache, IProductDatabase settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>(typeof(Product).Name);

            _distributedCache = distributedCache;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = "updateProduct";

            var updateproduct = _collection.ReplaceOne(request.Product.Id, request.Product);
            var updateproductconvert = JsonConvert.SerializeObject(updateproduct);
            var updateproductbyte = Encoding.UTF8.GetBytes(updateproductconvert);
            await _distributedCache.SetAsync(cacheKey, updateproductbyte);
            return new UpdateProductCommandResponse(request.Product);




        }
    }
}
