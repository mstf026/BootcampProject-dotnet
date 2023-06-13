using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OrderManufactureManager : IOrderManufactureService
    {
        private readonly ISubpieceService _subpieceService;
        private readonly IProductSubpieceService _productSubpieceService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;
        private readonly ISectionService _sectionService;


        public OrderManufactureManager(
            ISubpieceService subpieceService,
            IProductSubpieceService productSubpieceService,
            IOrderService orderService,
            IProductService productService,
            IDepartmentService departmentService,
            ISectionService sectionService)
        {
            _subpieceService = subpieceService;
            _productSubpieceService = productSubpieceService;
            _orderService = orderService;
            _productService = productService;
            _departmentService = departmentService;
            _sectionService = sectionService;
        }

        public IDataResult<List<Subpiece>> GetAllSubpiecesByStationId(int id)
        {
            return new SuccessDataResult<List<Subpiece>>(_subpieceService.GetByStationId(id),Messages.ProductsListed);
        }

        public IResult Add(int orderId, int stationId)
        {
            var order = _orderService.GetById(orderId).Data;
            if (order == null)
            {
                return new ErrorResult(Messages.OrderNotFound);
            }
            var productSubpieces = _productSubpieceService.GetByProductId(order.ProductId).Data;
            var product = _productService.GetById(order.ProductId).Data;
            var subpieces = _subpieceService.GetByStationId(stationId);
            var sections = _sectionService.GetAll().Data;
            foreach (var s in subpieces)
            {
                foreach (var p in productSubpieces)
                {
                    if (s.Id == p.SubpieceId)
                    {
                        if (s.UnitsInStock>=order.Quantity)
                        {
                            _subpieceService.Update(new Subpiece()
                            {
                                Id = s.Id,
                                UnitsInStock = s.UnitsInStock - order.Quantity,
                                StationId = s.StationId,
                                Cost = s.Cost, Name = s.Name,
                                UniqueNumber = s.UniqueNumber
                            });
                        }
                        else
                        {
                            return new ErrorResult(Messages.QuantityError);
                        }

                        foreach (var section in sections)
                        {
                            if (section.ModelNumber.Equals(order.ModelNumber))
                            {
                                var department = _departmentService.GetById(section.DepartmentId).Data;
                                if (stationId == 5)
                                {
                                    _departmentService.Update(new Department()
                                    {
                                        Id = department.Id,
                                        Name = department.Name,
                                        Area = department.Area,
                                        Budget = department.Budget - (order.Quantity * s.Cost) + (order.Quantity * product.Price) ,
                                        StockArea = department.StockArea,
                                    });
                                }
                                else
                                {
                                    _departmentService.Update(new Department()
                                    {
                                        Id = department.Id,
                                        Name = department.Name,
                                        Area = department.Area,
                                        Budget = department.Budget - order.Quantity * s.Cost,
                                        StockArea = department.StockArea,
                                    });
                                }
                                
                                
                            }
                        }
                        return new SuccessResult(Messages.SubpieceAddedToProduct);
                    }
                }
            }

            return new ErrorResult(Messages.ProductNotFound);
        }
    }
}
