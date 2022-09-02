using Core.Utilities.Results;
using Entities.Concrete;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace Business.Abstract
{
    public interface IShippingCompanyService
    {
        IResult BulkAdd(List<ShippingCompany> shippingCompany, Action<BulkOperation>? options);

        IResult Add(ShippingCompany shippingCompany);
        ShippingCompany GetById(int id);

        List<ShippingCompany> GetAll();
        ShippingCompany Get(Expression<Func<ShippingCompany, bool>> filter);
    }
}