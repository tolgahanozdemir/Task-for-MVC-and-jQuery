using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;
using Z.BulkOperations;

namespace WebUI.Controllers
{
    public class ShippingCompanyController : Controller
    {
        private readonly ILogger<ShippingCompanyController> _logger;
        private IProductService _productService;
        private IShippingCompanyService _shippingCompanyService;
        private ICategoryService _categoryService;
        public ShippingCompanyController(ILogger<ShippingCompanyController> logger, IProductService productService, IShippingCompanyService shippingCompanyService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _shippingCompanyService = shippingCompanyService;
            _categoryService = categoryService;
        }
        public IActionResult AddShippingCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddShippingCompany(ShippingCompanyViewModel shippingCompanyModel)
        {

            try
            {
                List<ShippingCompany> shippingCompaniesForDb = new List<ShippingCompany>();
                for (int i = 0; i < shippingCompanyModel.CompanyNames.Count; i++)
                {
                    ShippingCompany companyForList = new ShippingCompany
                    {
                        Name = shippingCompanyModel.CompanyNames[i]
                    };
                    shippingCompaniesForDb.Add(companyForList);
                }
                _shippingCompanyService.BulkAdd(shippingCompaniesForDb, options =>
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
        public List<ShippingCompany> GetShippingCompanies(string searchWord)
        {
            var filteredCompanies = new List<ShippingCompany>();
            if (searchWord != null)
            {
                searchWord = searchWord.ToLower();
                var data = _shippingCompanyService.GetAll();
                foreach (var item in data)
                {
                    if (item.Name.ToLower().Contains(searchWord))
                    {
                        filteredCompanies.Add(item);
                    }

                }
                return filteredCompanies;
            }
            return _shippingCompanyService.GetAll();
        }

        public IActionResult GetAllShippingCompanies()
        {
            return View();
        }
    }
}
