using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;
using test.Infrastructure.Interfaces;

namespace test.Infrastructure.CQRS.Handler.QueryHandlers.ProductQueryHandler
{
    public class GetProductByIdToCategoryhandler : IRequestHandler<GetProductByIdToCategoryRequest, GetProductByIdToCategoryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _distributedCache;

        public GetProductByIdToCategoryhandler(IProductRepository productRepository, IDistributedCache distributedCache)
        {
            _productRepository = productRepository;
            _distributedCache = distributedCache;
        }

        public async Task<GetProductByIdToCategoryResponse> Handle(GetProductByIdToCategoryRequest request, CancellationToken cancellationToken)
        {
            //var cacheKey = "productByIdCategory";
            //var getCategory = _productRepository.GetProductByIdToCategory(request.ProductId).Result;
            //var getCategoryConvert = JsonConvert.SerializeObject(getCategory);
            //var getCategoryByte = Encoding.UTF8.GetBytes(getCategoryConvert);
            //await _distributedCache.GetAsync(cacheKey);
            //return new GetProductByIdToCategoryResponse();
            return null;
        }
    }
}
