using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<ShippingCompany> GetAll()
        {
            return _shippingCompanyDal.GetAll();
        }
    }
}
