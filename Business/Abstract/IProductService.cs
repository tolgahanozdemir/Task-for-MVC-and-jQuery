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
        void BulkAdd(List<Product> product, Action<BulkOperation>? options);
        void BulkDelete(List<Product> product, Action<BulkOperation>? options);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetAll();
        Product Get(Expression<Func<Product, bool>> filter);
    }
}
