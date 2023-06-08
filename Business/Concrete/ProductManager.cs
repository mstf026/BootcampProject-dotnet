using Business.Abstract;
using Business.Constants;
using Core;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProduct_SubpieceService _productSubpieceService;
        private readonly ISubpieceService _subpieceService;

        public ProductManager(IProductDal productDal, IProduct_SubpieceService productSubpieceService, ISubpieceService subpieceService)
        {
            _productDal = productDal;
            _productSubpieceService = productSubpieceService;
            _subpieceService = subpieceService;
        }

        public IResult Add(Product product, int[] subpieceId)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name));
            if (result != null)
            {
                return result;
            }
            decimal Cost = 0;
            foreach (var s in subpieceId)
            {
                if (!_subpieceService.GetById(s).Success)
                {
                    return new ErrorResult(Messages.ProductNotFound);
                }
                Cost += _subpieceService.GetById(s).Data.Cost;
            }

            Cost *= (decimal)1.1;
            product.Price = Cost;
            _productDal.Add(product);
            foreach (var s in subpieceId)
            {
                var subpieceresult = _productSubpieceService.Add(new Product_Subpiece()
                {
                    ProductId = product.Id,
                    SubpieceId = s
                });
            }

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
            if (DateTime.Now.Hour== 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
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
