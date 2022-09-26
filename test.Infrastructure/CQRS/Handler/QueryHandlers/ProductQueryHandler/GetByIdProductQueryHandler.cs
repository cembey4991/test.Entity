using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;
using test.Infrastructure.Interfaces;

namespace test.Infrastructure.CQRS.Handler.QueryHandlers.ProductQueryHandler
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCache _distributedCache;

        public GetByIdProductQueryHandler(IDistributedCache distributedCache, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _distributedCache = distributedCache;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = "getByIdProduct";
            var getByIdProduct = _productRepository.FindById(request.ProductId);
            //var getByNameProductConvert = JsonConvert.SerializeObject(getByNameProduct);
            //var getByNameProductByte = Encoding.UTF8.GetBytes(getByNameProductConvert);
            //await _distributedCache.GetAsync(cacheKey);
            return new GetByIdProductQueryResponse(getByIdProduct);



        }
    }
}
