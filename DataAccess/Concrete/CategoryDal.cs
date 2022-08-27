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
    public class CategoryDal : ICategoryDal
    {
        public void Add(Category category)
        {
            using (var context = new TaskContext())
            {
                var addedEntity = context.Add(category);
                context.SaveChanges();
            }
        }

        public void BulkAdd(List<Category> category, Action<BulkOperation>? options)
        {
            using (var context = new TaskContext())
            {
                context.BulkInsert(category, options);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new TaskContext())
            {
                return filter == null
                    ? context.Set<Category>().ToList()
                    : context.Set<Category>().Where(filter).ToList();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (var context = new TaskContext())
            {
                return context.Set<Category>().SingleOrDefault(filter);
            }
        }
    }
}
