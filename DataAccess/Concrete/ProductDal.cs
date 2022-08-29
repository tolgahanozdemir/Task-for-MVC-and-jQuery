using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public void Delete(Product product)
        {
            using (var context = new TaskContext())
            {
                var deletedEntity = context.Entry(product);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (var context = new TaskContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
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

        public void Update(Product product)
        {
            using (var context = new TaskContext())
            {
                var updatedEntity = context.Entry(product);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
