using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        void BulkAdd(List<Product> product,Action<BulkOperation>? options);
        void Add(Product product);
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        void Update(Product product);
        void Delete(Product product);
        Product Get(Expression<Func<Product, bool>> filter);
    }
}
