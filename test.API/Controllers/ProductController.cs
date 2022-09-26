using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using test.Business.Dtos;
using test.Business.Interface;
using test.Infrastructure.CQRS.Commands.Request.ProductRequest;
using test.Infrastructure.CQRS.Commands.Response.ProductResponse;
using test.Infrastructure.CQRS.Queries.Request.ProductQueryRequest;
using test.Infrastructure.CQRS.Queries.Response.ProductQueryResponse;

namespace test.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        private readonly IMediator _mediatR;
        //private readonly IDistributedCache _distributedCache;

        public ProductController(IProductService productService, IMapper mapper, IMediator mediatR)
        {
            _productService = productService;
            _mapper = mapper;
            _mediatR = mediatR;
        }
        [HttpGet]
        public async Task<IActionResult> GetContainsProductName(string productName)
        {
            var products = await _productService.GetContainsProductName(productName);
            return Ok(products);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductMostCheap()
        {
            var product = await _productService.GetProductMostCheap();
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductMostExpensive()
        {
            var product = await _productService.GetProductMostExpensive();
            return Ok(product);
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest request)
        {
            List<GetAllProductQueryResponse> response = await _mediatR.Send(request);


            var result = _productService.GetAll();
            return Ok(result);
            //return Ok(_productService.GetAllProducts());
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetProductById([FromQuery] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediatR.Send(request);

            return Ok(_productService.FindById(request.ProductId));

            //var result = _productService.FindById(id);
            //return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommandRequest request)
        {
            AddProductCommandResponse response = await _mediatR.Send(request);
            var addProductDto = _mapper.Map<ProductDto>(response.Product);
            var result = await _productService.InsertOneAsync(addProductDto);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _mediatR.Send(request);
            // var addProductDto = _mapper.Map<ProductDto>(response);

            await _productService.DeleteById(request.Id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductCommandHandler(CommandRequest request)
        {
            await _productService.DeleteById(request.Product.Id);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductCommandHandler(CommandRequest request)
        {
            CommandResponse response = await _mediatR.Send(request);
            var addProductDto = _mapper.Map<ProductDto>(response.Product);
            var result = await _productService.InsertOneAsync(addProductDto);
            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductCommandHandler(CommandRequest request)
        {
            CommandResponse response = await _mediatR.Send(request);
            var updateProductDto = _mapper.Map<ProductDto>(response.Product);
            var result = await _productService.ReplaceOne(updateProductDto);
            return Ok(result);

        }


        //[HttpPut]
        //public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        //{
        //    var result = await _productService.UpdateProduct(request);
        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        //{
        //    var result = await _productService.ReplaceOne(request.Product);
        //    return Ok(result);
        //}

        //[NonAction]
        //[HttpGet]
        //[EnableQuery]
        //public async Task<IActionResult> GetAllProductsRedisCache([FromQuery] GetAllProductQueryRequest request)
        //{
        //    //    //var cacheKey = "productList";
        //    //    //string serializedProductList;
        //    //    //List<Product> productList = new();
        //    //    //var redisProductList = await _distributedCache.GetAsync(cacheKey);

        //    //    //productList = _productService.GetAllProducts();
        //    //    //serializedProductList = JsonConvert.SerializeObject(productList);
        //    //    //redisProductList = Encoding.UTF8.GetBytes(serializedProductList);
        //    //    ////DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
        //    //    ////     .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
        //    //    ////     .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        //    //    //await _distributedCache.SetAsync(cacheKey, redisProductList);

        //    //    //return Ok(productList);

        //    List<GetAllProductQueryResponse> result = await _mediatR.Send(request);
        //    return Ok(result);
        //}
        //[HttpPost]
        //public async Task<IActionResult> InsertProduct(AddProductCommandRequest product)
        //{
        //    // var cacheKey = "addProduct";
        //    //AddProductCommandResponse product = await _mediatR.Send(request);
        //    // var addProduct=JsonConvert.SerializeObject(product);
        //    // var addProductByte=Encoding.UTF8.GetBytes(addProduct);
        //    //await  _distributedCache.SetAsync(addProduct, addProductByte);


        //    // return Ok(product);
        //    //var addProduct=_productService.AddProduct(product);
        //    //return Ok(addProduct);
        //    //AddProductCommandResponse response = await _mediatR.Send(request);

        //    var result = await _productService.InsertProduct(product);
        //    await _mediatR.Publish(new ProductInsertNotification(result.Product));
        //    return Ok(result);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        //{
        //    //var cacheKey = "deleteProduct";
        //    //DeleteProductCommandResponse response=await _mediatR.Send(request);

        //    //var deletedProduct=JsonConvert.SerializeObject(response);
        //    //var deletedProductByte=Encoding.UTF8.GetBytes(deletedProduct);
        //    //await _distributedCache.RemoveAsync(deletedProduct);
        //    //return NoContent();
        //    //DeleteProductCommandResponse response = await _mediatR.Send(request);

        //    await _productService.DeleteProduct(request);
        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddProductCommandHandler(CommandRequest request)
        //{
        //    var result = await _productService.InsertOneAsync(request.Product);
        //    return Ok(result);
        //}
    }
}
