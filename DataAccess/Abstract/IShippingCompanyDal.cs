using Entities.Concrete;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace DataAccess.Abstract
{
    public interface IShippingCompanyDal
    {
        void BulkAdd(List<ShippingCompany> shippingCompany, Action<BulkOperation>? options);

        void Add(ShippingCompany shippingCompany);

        List<ShippingCompany> GetAll(Expression<Func<ShippingCompany, bool>> filter = null);
        ShippingCompany Get(Expression<Func<ShippingCompany, bool>> filter);
    }
}