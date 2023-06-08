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
    public class Product_SubpieceManager : IProduct_SubpieceService
    {
        private readonly IProduct_SubpieceDal _productSubpieceDal;

        public Product_SubpieceManager(IProduct_SubpieceDal productSubpieceDal)
        {
            _productSubpieceDal = productSubpieceDal;
        }
        public IResult Add(Product_Subpiece productSubpiece)
        {
            _productSubpieceDal.Add(productSubpiece);

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
