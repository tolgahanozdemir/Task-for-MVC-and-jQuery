using Core.Utilities.Results;
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
        IResult BulkAdd(List<Category> category, Action<BulkOperation>? options);
        IResult BulkDelete(List<Category> category, Action<BulkOperation>? options);
        IResult Add(Category category);
        IResult Delete(Category category);
        IDataResult<Category> GetById(int id);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> Get(Expression<Func<Category, bool>> filter);
    }
}
