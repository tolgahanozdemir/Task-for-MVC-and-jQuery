using Business.Abstract;
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

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void BulkAdd(List<Category> category, Action<BulkOperation>? options)
        {
            _categoryDal.BulkAdd(category, options);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void BulkDelete(List<Category> category, Action<BulkOperation>? options)
        {
            _categoryDal.BulkDelete(category,options);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}