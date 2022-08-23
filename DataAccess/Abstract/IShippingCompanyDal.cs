using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IShippingCompanyDal
    {
        void Add(ShippingCompany shippingCompany);
        List<ShippingCompany> GetAll(Expression<Func<ShippingCompany, bool>> filter = null);
    }
}
