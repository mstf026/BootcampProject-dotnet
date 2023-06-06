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
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessDataResult<Order>(Messages.Added);
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
