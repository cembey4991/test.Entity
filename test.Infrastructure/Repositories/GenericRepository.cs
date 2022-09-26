using MongoDB.Driver;
using System.Linq.Expressions;
using test.Entity.Entities;
using test.Infrastructure.Interfaces;
using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.Repositories
{
    public class GenericRepository<TDocument> : IGenericRepository<TDocument> where TDocument : BaseEntity
    {

        private readonly IMongoCollection<TDocument> _collection;
        public GenericRepository(IProductDatabase settings)
        {
            //var mongoClient = new MongoClient(options.Value.ConnectionString);
            //var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            //_collection = mongoDatabase.GetCollection<TDocument>(options.Value.ProductCollectionName);

            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(typeof(TDocument).Name);

        }
        //public Task<List<TDocument>> GetAll()
        //{
        //    return _collection.AsQueryable().ToListAsync();
        //}

        public async Task<bool> DeleteById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, id);
            var deleteResult = await _collection.DeleteOneAsync(filter);
            return true;
        }

        public TDocument FindById(string id)
        {

            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public async Task<bool> InsertOne(TDocument document)
        {

            _collection.InsertOne(document);
            return true;
        }

        public Task<TDocument> ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, document.Id);
            var table = _collection.FindOneAndReplaceAsync(filter, document);
            return table;
        }

        public async Task<TDocument> InsertOneAsync(TDocument document)
        {
            _collection.InsertOneAsync(document);
            return document;
        }

        public IQueryable<TDocument> GetAll(Expression<Func<TDocument, bool>> expression = null)
        {
            var result = _collection.AsQueryable();
            return result;
        }
    }
}
