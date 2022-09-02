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
    public interface IProductService
    {
        IResult BulkAdd(List<Product> product, Action<BulkOperation>? options);
        IResult BulkDelete(List<Product> product, Action<BulkOperation>? options);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> Get(Expression<Func<Product, bool>> filter);
        IDataResult<Product> GetById(int id);
    }
}
