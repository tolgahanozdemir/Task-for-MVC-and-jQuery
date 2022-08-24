using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public void BulkAdd(List<Product> product,Action<BulkOperation>? options)
        {
            _productdal.BulkAdd(product,options);
        }

        public void Add(Product product)
        {
            if (product.SellingPrice >0 && product.PurchasePrice>0)
            {
                _productdal.Add(product);
            }
            else
            {
                throw new Exception("Tüm alanlar doldurulmak zorundadır.");
            }
            
        }

        public List<Product> GetAll()
        {
            return _productdal.GetAll();
        }
    }
}
