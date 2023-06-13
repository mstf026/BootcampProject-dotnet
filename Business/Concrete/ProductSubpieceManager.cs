using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductSubpieceManager : IProductSubpieceService
    {
        private readonly IProduct_SubpieceDal _productSubpieceDal;
        private readonly ISubpieceService _subpieceService;
        private readonly IProductService _productService;

        public ProductSubpieceManager(IProduct_SubpieceDal productSubpieceDal,
            ISubpieceService subpieceService,
            IProductService productService)
        {
            _productSubpieceDal = productSubpieceDal;
            _subpieceService = subpieceService;
            _productService = productService;
        }
        public IResult Add(int[] subpieceId)
        {
            decimal cost = 0;
            foreach (var s in subpieceId)
            {
                if (!_subpieceService.GetById(s).Success)
                {
                    return new ErrorResult(Messages.ProductNotFound);
                }
                cost += _subpieceService.GetById(s).Data.Cost;
            }

            cost *= (decimal)1.1;
            var product = _productService.GetLastProduct().Data;
            _productService.Update(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = cost,
                ModelNumber = product.ModelNumber,
                Type = product.Type
            });
            foreach (var s in subpieceId)
            {
                _productSubpieceDal.Add(new Product_Subpiece()
                {
                    ProductId = product.Id,
                    SubpieceId = s
                });
            }

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Product_Subpiece>> GetAll()
        {
            return new SuccessDataResult<List<Product_Subpiece>>(_productSubpieceDal.GetAll());
        }

        public IDataResult<List<Product_Subpiece>> GetByProductId(int productId)
        {
            return new SuccessDataResult<List<Product_Subpiece>>(_productSubpieceDal.GetAll(p => p.ProductId == productId));
        }
    }
}
