using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(ShippingCompany shippingCompany)
        {
            _shippingCompanyDal.Add(shippingCompany);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult BulkAdd(List<ShippingCompany> shippingCompany, Action<BulkOperation>? options)
        {
            _shippingCompanyDal.BulkAdd(shippingCompany, options);
            return new SuccessResult(Messages.ProductsAdded);
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