using MediatR;
using test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;
using test.Infrastructure.Interfaces;

namespace test.Infrastructure.CQRS.Handler.QueryHandlers.ProductQueryHandler
{
    public class GetMostCheapProductHandler : IRequestHandler<GetMostCheapProductRequest, GetMostCheapProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetMostCheapProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetMostCheapProductResponse> Handle(GetMostCheapProductRequest request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetProductMostCheap();
            return new GetMostCheapProductResponse(request.Product);




            //return new GetMostCheapProductResponse(request.Product);
        }
    }
}
