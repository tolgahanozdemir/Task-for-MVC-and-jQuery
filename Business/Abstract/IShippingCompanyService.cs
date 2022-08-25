using Entities.Concrete;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace Business.Abstract
{
    public interface IShippingCompanyService
    {
        void BulkAdd(List<ShippingCompany> shippingCompany, Action<BulkOperation>? options);

        void Add(ShippingCompany shippingCompany);

        List<ShippingCompany> GetAll();
        ShippingCompany Get(Expression<Func<ShippingCompany, bool>> filter);
    }
}