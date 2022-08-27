using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace DataAccess.Abstract
{
    public interface ICategoryDal
    {
        void BulkAdd(List<Category> category, Action<BulkOperation>? options);

        void Add(Category category);

        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        Category Get(Expression<Func<Category, bool>> filter);
    }
}
