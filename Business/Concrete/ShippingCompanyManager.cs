using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace Business.Concrete
{
    public class ShippingCompanyManager : IShippingCompanyService
    {
        private IShippingCompanyDal _shippingCompanyDal;

        public ShippingCompanyManager(IShippingCompanyDal shippingCompanyDal)
        {
            _shippingCompanyDal = shippingCompanyDal;
        }

        public void Add(ShippingCompany shippingCompany)
        {
            _shippingCompanyDal.Add(shippingCompany);
        }

        public void BulkAdd(List<ShippingCompany> shippingCompany, Action<BulkOperation>? options)
        {
            _shippingCompanyDal.BulkAdd(shippingCompany, options);
        }

        public ShippingCompany Get(Expression<Func<ShippingCompany, bool>> filter)
        {
            return _shippingCompanyDal.Get(filter);
        }

        public List<ShippingCompany> GetAll()
        {
            return _shippingCompanyDal.GetAll();
        }

        public ShippingCompany GetById(int id)
        {
            return _shippingCompanyDal.GetById(id);
        }
    }
}