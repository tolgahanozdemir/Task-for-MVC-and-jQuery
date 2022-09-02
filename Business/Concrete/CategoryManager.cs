using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult BulkAdd(List<Category> category, Action<BulkOperation>? options)
        {
            _categoryDal.BulkAdd(category, options);
            return new SuccessResult(Messages.ProductsAdded);
        }

        public IDataResult<Category> Get(Expression<Func<Category, bool>> filter)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(filter));
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Ürün Silindi.");
        }

        public IResult BulkDelete(List<Category> category, Action<BulkOperation>? options)
        {
            _categoryDal.BulkDelete(category,options);
            return new SuccessResult("Ürünler Silindi.");
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.GetById(id));
        }
    }
}