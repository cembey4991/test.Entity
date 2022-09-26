using System.Linq.Expressions;

namespace test.Business.Interface
{
    public interface IGenericService<TDocument, TDto>
    {
        IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null);
        TDto FindById(string id);
        Task<bool> InsertOne(TDto tDto);
        Task<TDocument> ReplaceOne(TDto tDto);

        Task<bool> DeleteById(string id);
        Task<TDto> InsertOneAsync(TDto tDto);

    }
}
