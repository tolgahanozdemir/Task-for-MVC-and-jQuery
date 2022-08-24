using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace DataAccess.Concrete
{
    public class ProductDal : IProductDal
    {
        public void Add(Product product)
        {
            using (var context = new TaskContext())
            {
                var addedEntity = context.Add(product);
                context.SaveChanges();
            }
        }
        public void BulkAdd(List<Product> product,Action<BulkOperation>? options = null)
        {
            using (var context = new TaskContext())
            {
                context.BulkInsert(product, options);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new TaskContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }
    }
}
