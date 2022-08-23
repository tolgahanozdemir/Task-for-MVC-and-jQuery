using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);
            return Ok("Product Added");
        }

        [HttpPost("bulkadd")]
        public IActionResult BulkAdd(List<Product> product)
        {
            _productService.BulkAdd(product);
            return Ok("Products Added");
        }
    }
}
