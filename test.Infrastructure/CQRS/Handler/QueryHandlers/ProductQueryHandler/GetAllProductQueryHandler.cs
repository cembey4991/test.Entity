using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;
using test.Infrastructure.Interfaces;

namespace test.Infrastructure.CQRS.Handler.QueryHandlers.ProductQueryHandler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _distributedCache;
        public GetAllProductQueryHandler(IProductRepository productRepository, IDistributedCache distributedCache)
        {
            _productRepository = productRepository;
            _distributedCache = distributedCache;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            //var cacheKey = "productList";
            //string serializedProductList;
            //List<Product> productList = new();
            //var redisProductList = await _distributedCache.GetAsync(cacheKey);

            //productList = _productService.GetAllProducts();
            //serializedProductList = JsonConvert.SerializeObject(productList);
            //redisProductList = Encoding.UTF8.GetBytes(serializedProductList);
            ////DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
            ////     .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
            ////     .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            //await _distributedCache.SetAsync(cacheKey, redisProductList);

            //return Ok(productList);



            //var cacheKey = "productList";
            //string serializedProductList;
            ////List<Product> products1 = new();
            //var productList = new List<GetAllProductQueryResponse>();
            //var products = _productRepository.GetAllProductsAsync().Result;

            //foreach (var product in products)
            //{
            //    productList.Add(new GetAllProductQueryResponse() { Category = product.Category, Name = product.Name, Price = product.Price, Id = product.Id });
            //    var redisProductList = await _distributedCache.GetAsync(cacheKey);
            //    serializedProductList = JsonConvert.SerializeObject(productList);
            //    redisProductList = Encoding.UTF8.GetBytes(serializedProductList);
            //    await _distributedCache.SetAsync(cacheKey, redisProductList);
            //}
            //return productList;




            return null;
        }
    }
}
