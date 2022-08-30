using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;
using Z.BulkOperations;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private IProductService _productService;
        private IShippingCompanyService _shippingCompanyService;
        private ICategoryService _categoryService;
        public ProductController(ILogger<ProductController> logger, IProductService productService, IShippingCompanyService shippingCompanyService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _shippingCompanyService = shippingCompanyService;
            _categoryService = categoryService;
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
                    var category = _categoryService.Get(x => x.Id == Convert.ToInt32(products.CategoryIds[i]));
                    var company = _shippingCompanyService.Get(x => x.Id == Convert.ToInt32(products.CargoCompanyIds[i]));
                    Product productForList = new Product
                    {
                        Name = products.ProductNames[i],
                        PurchasePrice = (float)products.PurchasePrices[i],
                        SellingPrice = (float)products.SalePrices[i],
                        Description = products.Descriptions[i],
                        StockAmount = products.Stocks[i],
                        ShippingId = company.Id,
                        CategoryId = category.Id
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
            catch (Exception ex)
            {
                ViewBag.ErrMsg = "Failed " + ex.Message;

            }
            return View();
        }
        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            var product = _productService.Get(x => x.Id == productId);
            _productService.Delete(product);
            return Json(new { success = true, responseText = "Deleted Scussefully" });
        }

        public IActionResult GetAllProducts()
        {
            return View();
        }
        public List<ProductModelForListProducts> GetProducts()
        {
            var products = _productService.GetAll();
            var data = new List<ProductModelForListProducts>();
            foreach (var item in products)
            {
                var category = _categoryService.Get(x => x.Id == item.CategoryId);
                var company = _shippingCompanyService.Get(x => x.Id == item.ShippingId);
                ProductModelForListProducts product = new ProductModelForListProducts
                {
                    ProductId = item.Id,
                    ProductName = item.Name,
                    PurchasePrice = item.PurchasePrice,
                    SalePrice = item.SellingPrice,
                    Description = item.Description,
                    Stock = item.StockAmount,
                    CargoCompanyName = company.Name,
                    CategoryName = category.Name
                };
                data.Add(product);
            }
            return data;
        }
    }
}
