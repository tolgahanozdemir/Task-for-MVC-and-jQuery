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
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public void BulkAdd(List<Product> product)
        {
            _productdal.BulkAdd(product);
        }

        public void Add(Product product)
        {
            _productdal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productdal.GetAll();
        }
    }
}
