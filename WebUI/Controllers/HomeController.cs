using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;
using Z.BulkOperations;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel products)
        {
            
            try
            {
                List<Product> productsForDb = new List<Product>();
                for (int i = 0; i < products.ProductNames.Count; i++)
                {
                    Product productForList = new Product
                    {
                        Name = products.ProductNames[i],
                        PurchasePrice = (float)products.PurchasePrices[i],
                        SellingPrice = (float)products.SalePrices[i],
                        Description = products.Descriptions[i],
                        StockAmount = products.Stocks[i],
                        ShippingDetail = products.CargoCompanyIds[i].ToString()
                    };
                    productsForDb.Add(productForList);
                }

                _productService.BulkAdd(productsForDb, options =>
                {
                    options.InsertIfNotExists = true;
                    options.ErrorMode = ErrorModeType.ThrowException;
                });
                ViewBag.Success = "Succesfully Inserted";
            }
            catch(Exception ex)
            {
                ViewBag.ErrMsg = "Failed " + ex.Message;

            }
            return View();
        }

        public IActionResult GetAllProducts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Product> GetProducts()
        {
            var products = _productService.GetAll();
            return products;
        }
    }
}