using MediatR;
using MongoDB.Driver;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Commands.Request.ProductRequest;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;
using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.CQRS.Handler.CommandsHandlers.ProductHandler
{
    public class CommandHandler : IRequestHandler<CommandRequest, CommandResponse>
    {
        private readonly IMongoCollection<Product> _collection;


        public CommandHandler(IProductDatabase settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>(typeof(Product).Name);

        }

        public async Task<CommandResponse> Handle(CommandRequest request, CancellationToken cancellationToken)
        {
            var addProduct = _collection.InsertOneAsync(request.Product);
            if(addProduct != null)
            {
                return new CommandResponse(request.Product);
            }

            var updateProduct = _collection.ReplaceOne(request.Product.Id, request.Product);
            if (updateProduct != null)
            {
                return new CommandResponse(request.Product);
            }
            var deleteProduct = _collection.DeleteOne(request.Product.Id);
            
            return new CommandResponse(product: request.Product);
        }
    }
}
