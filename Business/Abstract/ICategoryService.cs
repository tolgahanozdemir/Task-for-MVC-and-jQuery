using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void BulkAdd(List<Category> category, Action<BulkOperation>? options);
        void BulkDelete(List<Category> category, Action<BulkOperation>? options);
        void Add(Category category);
        void Delete(Category category);
        List<Category> GetAll();
        Category Get(Expression<Func<Category, bool>> filter);
    }
}
