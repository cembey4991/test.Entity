using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using test.Infrastructure.CQRS.Queries.Request.CategoryQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.CategoryQueryResponse;
using test.Infrastructure.Interfaces;

namespace test.Infrastructure.CQRS.Handler.QueryHandlers.CategoryQueryHandler
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDistributedCache _distributedCache;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IDistributedCache distributedCache)
        {
            _categoryRepository = categoryRepository;
            _distributedCache = distributedCache;
        }

        public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            //var cacheKey = "categoryList";
            //string serializedCategoryList;
            //var categoryList = new List<GetAllCategoriesQueryResponse>();
            //var categories = _categoryRepository.GetAllCategories().Result;
            //foreach (var category in categories)
            //{
            //    categoryList.Add(new GetAllCategoriesQueryResponse() { CategoryId = category.Id, CategoryName = category.Name });
            //    var redisCategoryList = await _distributedCache.GetAsync(cacheKey, cancellationToken);

            //    serializedCategoryList = JsonConvert.SerializeObject(categoryList);
            //    redisCategoryList = Encoding.UTF8.GetBytes(serializedCategoryList);
            //    await _distributedCache.SetAsync(cacheKey, redisCategoryList);
            //}
            //return categoryList;

            return null;
        }
    }
}
