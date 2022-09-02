using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Z.BulkOperations;

namespace MVC.Controllers
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
                    ShippingId = company.Data.Id,
                    CategoryId = category.Data.Id
                };
                productsForDb.Add(productForList);
            }


            var result = _productService.BulkAdd(productsForDb, options =>
            {
                options.InsertIfNotExists = true;
            });
            //_productService.Add(productsForDb[0]);
            if (result.Success)
            {
                ViewBag.Success = result.Message;
            }
            else
            {
                ViewBag.ErrMsg = "Failed " + result.Message;
            }
            return View();
        }
        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            var product = _productService.Get(x => x.Id == productId);
            _productService.Delete(product.Data);
            return Json(new { success = true, responseText = "Deleted Scussefully" });
        }

        [HttpPost]
        public JsonResult DeleteSelectedProducts(List<int> productIds)
        {
            List<Product> products = new List<Product>();
            foreach (int item in productIds)
            {
                var product = _productService.Get(x => x.Id == item);
                products.Add(product.Data);
            }
            _productService.BulkDelete(products, options =>
            {
                options.InsertIfNotExists = true;
                options.ErrorMode = ErrorModeType.ThrowException;
            });
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
            foreach (var item in products.Data)
            {
                var category = _categoryService.Get(x => x.Id == item.CategoryId);
                var company = _shippingCompanyService.Get(x => x.Id == item.ShippingId);
                ProductModelForListProducts product = new ProductModelForListProducts
                {
                    Id = item.Id,
                    Name = item.Name,
                    PurchasePrice = item.PurchasePrice,
                    SalePrice = item.SellingPrice,
                    Description = item.Description,
                    Stock = item.StockAmount,
                    CargoCompanyName = company.Data.Name,
                    CategoryName = category.Data.Name
                };
                data.Add(product);
            }
            return data;
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = _productService.GetById(id);

            ProductModelForListProducts productToView = new ProductModelForListProducts
            {
                Id = product.Data.Id,
                Name = product.Data.Name,
                PurchasePrice = product.Data.PurchasePrice,
                SalePrice = product.Data.SellingPrice,
                Description = product.Data.Description,
                Stock = product.Data.StockAmount,
                CargoCompanyName = _shippingCompanyService.GetById(product.Data.ShippingId).Data.Name,
                CategoryName = _categoryService.GetById(product.Data.CategoryId).Data.Name
            };

            return View(productToView);
        }
        [HttpPost]
        public IActionResult UpdateProduct(ProductModelForListProducts product)
        {
            Product productToUpdate = new Product
            {
                Id = product.Id,
                Name = product.Name,
                SellingPrice = product.SalePrice,
                PurchasePrice = product.PurchasePrice,
                Description = product.Description,
                StockAmount = product.Stock,
                ShippingId = _shippingCompanyService.Get(x => x.Name == product.CargoCompanyName).Data.Id,
                CategoryId = _categoryService.Get(x => x.Name == product.CategoryName).Data.Id
            };


            _productService.Update(productToUpdate);
            return View("GetAllProducts");
        }
    }
}
