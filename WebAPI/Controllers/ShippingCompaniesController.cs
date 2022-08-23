using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompaniesController : ControllerBase
    {
        private IShippingCompanyService _shippingCompanyService;

        public ShippingCompaniesController(IShippingCompanyService shippingCompanyService)
        {
            _shippingCompanyService = shippingCompanyService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var data = _shippingCompanyService.GetAll();
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult Add(ShippingCompany shippingCompany)
        {
            _shippingCompanyService.Add(shippingCompany);
            return Ok("Company Added");
        }
    }
}
