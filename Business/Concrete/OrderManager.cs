using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ISubpieceService _subpieceService;
        private readonly IProductSubpieceService _productSubpieceService;
        public OrderManager(IOrderDal orderDal, ISubpieceService subpieceService, IProductSubpieceService productSubpieceService)
        {
            _orderDal = orderDal;
            _subpieceService = subpieceService;
            _productSubpieceService = productSubpieceService;
        }

        public IResult Add(Order order)
        {

            var result = _productSubpieceService.GetByProductId(order.ProductId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ProductIdError);
            }

            var subpieces = result.Data;
            foreach (var s in subpieces)
            {
                var orderResult = CheckIfAnySubpieceIsOutOfStock(s.SubpieceId, order.Quantity);
                if (!orderResult.Success)
                {
                    return new ErrorResult(Messages.NoStock);
                }
            }
            if (order.Quantity % 5 != 0)
            {

                return new ErrorResult(Messages.QuantityError);
            }
            _orderDal.Add(order);
            return new SuccessResult();
        }

        private IResult CheckIfAnySubpieceIsOutOfStock(int subpieceId,int orderQuantity)
        {
            var result = _subpieceService.GetById(subpieceId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            if (result.Data.UnitsInStock < orderQuantity || orderQuantity < 0)
            {
                return new ErrorResult(Messages.QuantityError);
            }

            return new SuccessResult();
        }

        public IResult Add(Product product, Subpiece subpiece)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=>o.Id == id));
        }
    }
}
