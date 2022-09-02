using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
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

        public IResult BulkAdd(List<Product> product, Action<BulkOperation>? options)
        {
            _productdal.BulkAdd(product, options);
            return new SuccessResult(Messages.ProductsAdded);
        }

        public IResult Add(Product product)
        {
            if (product.SellingPrice > 0 && product.PurchasePrice > 0)
            {
                _productdal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductCannotAdded);
            }
        }

        public List<Product> GetAll()
        {
            return _productdal.GetAll();
        }

        public IResult Delete(Product product)
        {
            _productdal.Delete(product);
            return new SuccessResult("Ürün Silindi.");
        }

        public IResult Update(Product product)
        {
            _productdal.Update(product);
            return new SuccessResult("Ürün Güncellendi.");
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productdal.Get(filter);
        }

        public IResult BulkDelete(List<Product> product, Action<BulkOperation>? options)
        {
            _productdal.BulkDelete(product, options);
            return new SuccessResult("Ürünler Silindi.");
        }

        public Product GetById(int id)
        {
            return _productdal.GetById(id);
        }
    }
}