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
    public class ShippingCompanyDal : IShippingCompanyDal
    {
        public void Add(ShippingCompany shippingCompany)
        {
            using (var context = new TaskContext())
            {
                var addedEntity = context.Add(shippingCompany);
                context.SaveChanges();
            }
        }

        public void BulkAdd(List<ShippingCompany> shippingCompany, Action<BulkOperation>? options)
        {
            using (var context = new TaskContext())
            {
                context.BulkInsert(shippingCompany, options);
            }
        }

        public List<ShippingCompany> GetAll(Expression<Func<ShippingCompany, bool>> filter = null)
        {
            using (var context = new TaskContext())
            {
                return filter == null
                    ? context.Set<ShippingCompany>().ToList()
                    : context.Set<ShippingCompany>().Where(filter).ToList();
            }
        }
        public ShippingCompany Get(Expression<Func<ShippingCompany, bool>> filter)
        {
            using (var context = new TaskContext())
            {
                var data = context.Set<ShippingCompany>().SingleOrDefault(filter);
                return data;
            }
        }
    }
}
