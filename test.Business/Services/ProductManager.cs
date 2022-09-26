using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using test.Business.Dtos;
using test.Business.Interface;
using test.Entity.Entities;
using test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;
using test.Infrastructure.Interfaces;


namespace test.Business.Services
{

    public class ProductManager : GenericManager<Product, ProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<IProductRepository> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;



        public ProductManager(IProductRepository productRepository, IMediator mediator, ILogger<IProductRepository> logger, IMapper mapper) : base(productRepository, logger, mapper)
        {
            _productRepository = productRepository;
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }
        //public async Task<List<Product>> GetAllProductsAsync()
        //{
        //    _logger.LogInformation("Testtttttt");
        //    List<GetAllProductQueryResponse> result = await _mediator.Send(new GetAllProductQueryRequest());
        //    return null;
        //   // return await _productRepository.GetAllProductsAsync();
        //}
        //public async Task<Product> GetProductById(string id)
        //{
        //    GetByIdProductQueryResponse response = await _mediator.Send(new GetByIdProductQueryRequest());
        //    return null;
        //    //return await _productRepository.GetProductById(id);
        //}
        //public async Task<AddProductCommandResponse> InsertProduct(AddProductCommandRequest request)
        //{
        //    AddProductCommandResponse response = await _mediator.Send(request);
        //    return response;
        //}
        //public async Task<bool> DeleteProduct(DeleteProductCommandRequest request)
        //{
        //    DeleteProductCommandResponse response = await _mediator.Send(request);
        //    return response != null;
        //}

        //public async Task<Product> UpdateProduct(UpdateProductCommandRequest request)
        //{
        //    UpdateProductCommandResponse response = await _mediator.Send(request);

        //    //var product = await _productRepository.UpdateProduct(request);
        //    // return product;

        //    return null;
        //}


        public Task<List<Product>> GetProductMostExpensive()
        {
            return _productRepository.GetProductMostExpensive();
        }

        public async Task<List<Product>> GetProductMostCheap()
        {
            GetMostCheapProductResponse response = await _mediator.Send(new GetMostCheapProductRequest());
            var cheapProduct = await _productRepository.GetProductMostCheap();
            return cheapProduct;
        }

        public Task<List<Product>> GetContainsProductName(string productName)
        {
            return _productRepository.GetContainsProductName(productName);
        }

    }
}
