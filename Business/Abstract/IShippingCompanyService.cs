using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShippingCompanyService
    {
        void Add(ShippingCompany shippingCompany);
        List<ShippingCompany> GetAll();
    }
}
