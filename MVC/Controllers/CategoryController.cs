using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Z.BulkOperations;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private IProductService _productService;
        private IShippingCompanyService _shippingCompanyService;
        private ICategoryService _categoryService;
        public CategoryController(ILogger<CategoryController> logger, IProductService productService, IShippingCompanyService shippingCompanyService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _shippingCompanyService = shippingCompanyService;
            _categoryService = categoryService;
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                List<Category> categoriesForDb = new List<Category>();
                for (int i = 0; i < categoryViewModel.CategoryNames.Count; i++)
                {
                    Category categoryForList = new Category
                    {
                        Name = categoryViewModel.CategoryNames[i]
                    };
                    categoriesForDb.Add(categoryForList);
                }
                _categoryService.BulkAdd(categoriesForDb, options =>
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

        public IActionResult GetAllCategories()
        {
            return View();
        }


        public List<Category> GetCategories(string searchWord)
        {
            var filteredCategories = new List<Category>();
            if (searchWord != null)
            {
                searchWord = searchWord.ToLower();
                var data = _categoryService.GetAll();
                foreach (var item in data.Data)
                {
                    if (item.Name.ToLower().Contains(searchWord))
                    {
                        filteredCategories.Add(item);
                    }

                }
                return filteredCategories;
            }
            return _categoryService.GetAll().Data;
        }

        [HttpPost]
        public JsonResult DeleteCategory(int categoryId)
        {
            var product = _categoryService.Get(x => x.Id == categoryId);
            _categoryService.Delete(product.Data);
            return Json(new { success = true, responseText = "Deleted Scussefully" });
        }

        [HttpPost]
        public JsonResult DeleteSelectedCategories(List<int> categoryIds)
        {
            List<Category> categories = new List<Category>();
            foreach (int item in categoryIds)
            {
                var product = _categoryService.Get(x => x.Id == item);
                categories.Add(product.Data);
            }
            _categoryService.BulkDelete(categories, options =>
            {
                options.InsertIfNotExists = true;
                options.ErrorMode = ErrorModeType.ThrowException;
            });
            return Json(new { success = true, responseText = "Deleted Scussefully" });
        }


        public IActionResult UpdateCategory()
        {
            return View();
        }
    }
}
