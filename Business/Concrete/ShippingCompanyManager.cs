using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
            _shippingCompanyDal.BulkAdd(shippingCompany,options);
        }

        public ShippingCompany Get(Expression<Func<ShippingCompany, bool>> filter)
        {
            return _shippingCompanyDal.Get(filter);
        }

        public List<ShippingCompany> GetAll()
        {
            return _shippingCompanyDal.GetAll();
        }
    }
}
