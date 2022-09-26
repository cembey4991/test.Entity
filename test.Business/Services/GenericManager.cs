using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using test.Business.Dtos;
using test.Business.Interface;
using test.Entity.Entities;
using test.Infrastructure.Interfaces;

namespace test.Business.Services
{

    public class GenericManager<TDocument, TDto> : IGenericService<TDocument, TDto> where TDto : EntityDto where TDocument : BaseEntity
    {
        private readonly IGenericRepository<TDocument> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IProductRepository> _logger;

        public GenericManager(IGenericRepository<TDocument> repository, ILogger<IProductRepository> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //public async Task<List<TDocument>> GetAll()
        //{
        //    _logger.LogInformation("Testtttttt");
        //    return await _repository.GetAll();
        //}

        public Task<bool> DeleteById(string id)
        {
            return _repository.DeleteById(id);
        }

        public TDto FindById(string id)
        {
            var repo = _repository.FindById(id);
            return _mapper.Map<TDto>(repo);
        }

        //public async Task<bool> InsertOne(TDocument document)
        //{
        //    var result = await _repository.InsertOne(document);
        //    return result;
        //}

        //public async Task<TDocument> ReplaceOne(TDocument document)
        //{
        //    return await _repository.ReplaceOne(document);
        //}

        //public async Task<TDocument> InsertOneAsync(TDocument document)
        //{

        //    return await _repository.InsertOneAsync(document);
        //}

        //public IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null)
        //{
        //    var predicate = _mapper.Map<Expression<Func<TDocument, bool>>>(expression);
        //    return _repository.GetAll(predicate).Select(_mapper.Map<TDto>).ToList();
        //}         

        public async Task<bool> InsertOne(TDto tDto)
        {
            var entity = _mapper.Map<TDocument>(tDto);
            var result = await _repository.InsertOne(entity);
            return result;

        }

        //public async Task ReplaceOne(TDto tDto)
        //{
        //    var entity = _mapper.Map<TDocument>(tDto);
        //    await _repository.ReplaceOne(entity);

        //}

        public async Task<TDto> InsertOneAsync(TDto tDto)
        {
            var entity = _mapper.Map<TDocument>(tDto);
            var result = await _repository.InsertOneAsync(entity);
            return tDto;
        }



        public IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null)
        {
            var predicate = _mapper.Map<Expression<Func<TDocument, bool>>>(expression);
            return _repository.GetAll(predicate).Select(_mapper.Map<TDto>).ToList();

        }

        public async Task<TDocument> ReplaceOne(TDto tDto)
        {
            var entity = _mapper.Map<TDocument>(tDto);
            var result = await _repository.ReplaceOne(entity);
            return entity;
        }
    }
}
