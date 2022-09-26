using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using test.Business.Dtos;
using test.Business.Interface;
using test.Entity.Entities;
using test.Infrastructure.Interfaces;

namespace test.Business.Services
{
    public class CategoryManager : GenericManager<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<IProductRepository> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryManager(ICategoryRepository repository, ILogger<IProductRepository> logger, IMapper mapper) : base(repository, logger, mapper)
        {
            _categoryRepository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //public CategoryManager(ICategoryRepository categoryRepository, IMediator mediator)
        //{
        //    _categoryRepository = categoryRepository;
        //    _mediator = mediator;
        //}



        public Task<List<Product>> GetCategoryByIdToProducts(string id)
        {
            return _categoryRepository.GetCategoryByIdToProducts(id);
        }
    }
}
