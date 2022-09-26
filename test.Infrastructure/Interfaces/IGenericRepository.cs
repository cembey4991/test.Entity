using System.Linq.Expressions;
using test.Entity.Entities;

namespace test.Infrastructure.Interfaces
{
    public interface IGenericRepository<TDocument> where TDocument : BaseEntity
    {
        IQueryable<TDocument> GetAll(Expression<Func<TDocument, bool>> expression = null);
        TDocument FindById(string id);
        Task<bool> InsertOne(TDocument document);
        Task<TDocument> InsertOneAsync(TDocument document);
        Task<TDocument> ReplaceOne(TDocument document);
        Task<bool> DeleteById(string id);
    }
}
