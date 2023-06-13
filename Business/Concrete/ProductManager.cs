using Business.Abstract;
using Business.Constants;
using Core;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }


        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name));
            if (result != null)
            {
                return result;
            }
            decimal cost = 0;

            product.Price = cost;
            _productDal.Add(product);

            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Product product)
        {
            var result = _productDal.Get(p=>p.Id==product.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            _productDal.Update(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                ModelNumber = product.ModelNumber,
                Price = product.Price,
                Type = product.Type
            });

            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.Name == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<Product> GetLastProduct()
        {
            var result = _productDal.GetAll().ToArray();

            return new SuccessDataResult<Product>(result[result.Length-1]);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.Id == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Price >= min && p.Price <= max));
        }
    }
}
