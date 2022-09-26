using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Commands.Request.ProductRequest;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;
using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.CQRS.Handler.CommandsHandlers.ProductHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly IDistributedCache _distributedCache;
        public DeleteProductCommandHandler(IProductDatabase settings, IDistributedCache distributedCache)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>(typeof(Product).Name);
            _distributedCache = distributedCache;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            //var cacheKey = "deleteProduct";
            //DeleteProductCommandResponse response = await _mediatR.Send(request);

            //var deletedProduct = JsonConvert.SerializeObject(response);
            //var deletedProductByte = Encoding.UTF8.GetBytes(deletedProduct);
            //await _distributedCache.RemoveAsync(deletedProduct);
            //return NoContent();

            var cacheKey = "deleteProduct";
            var filter = Builders<Product>.Filter.Eq(document => document.Id, request.Id);
            var deleteResult = await _collection.DeleteOneAsync(filter);

            //var deletedProduct = JsonConvert.SerializeObject(result);
            //var deletedProductByte = Encoding.UTF8.GetBytes(deletedProduct);
            //await _distributedCache.RemoveAsync(deletedProduct);

            return new DeleteProductCommandResponse();



        }
    }
}
