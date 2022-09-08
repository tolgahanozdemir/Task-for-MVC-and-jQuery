using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [ValidationAspect(typeof(ProductValidatorForBulk))]
        public IResult BulkAdd(List<Product> products, Action<BulkOperation>? options)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(products));

            if (result != null)
            {
                return result;
            }

            _productdal.BulkAdd(products, options);
            return new SuccessResult(Messages.ProductsAdded);
        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("moderator")]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(), Messages.ProductsListed);
        }

        public IResult Delete(Product product)
        {
            _productdal.Delete(product);
            return new SuccessResult("Ürün Silindi.");
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productdal.Update(product);
            return new SuccessResult("Ürün Güncellendi.");
        }

        public IDataResult<Product> Get(Expression<Func<Product, bool>> filter)
        {
            return new SuccessDataResult<Product>(_productdal.Get(filter));
        }

        public IResult BulkDelete(List<Product> product, Action<BulkOperation>? options)
        {
            _productdal.BulkDelete(product, options);
            return new SuccessResult("Ürünler Silindi.");
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productdal.GetById(id));
        }

        private IResult CheckIfProductNameExists(List<Product> products)
        {
            var data = _productdal.GetAll();
            for (int i = 0; i < products.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    if (products[i].Name == data[j].Name)
                    {
                        return new ErrorResult("Aynı isimde 1'den fazla ürün olamaz.");
                    }
                }
            }

            return new SuccessResult();
        }
    }
}