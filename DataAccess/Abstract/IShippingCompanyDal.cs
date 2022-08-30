using Entities.Concrete;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace DataAccess.Abstract
{
    public interface IShippingCompanyDal : IEntityRepository<ShippingCompany>
    {
    }
}