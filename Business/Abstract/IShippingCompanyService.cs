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
        IDataResult<ShippingCompany> GetById(int id);
        IDataResult<List<ShippingCompany>> GetAll();
        IDataResult<ShippingCompany> Get(Expression<Func<ShippingCompany, bool>> filter);
    }
}