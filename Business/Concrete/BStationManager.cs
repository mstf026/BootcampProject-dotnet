using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BStationManager : IStationOrderService
    {
        private readonly ISubpieceService _subpieceService;

        public BStationManager(ISubpieceService subpieceService)
        {
            _subpieceService = subpieceService;
        }
        public IDataResult<List<Subpiece>> GetAllSubpiecesByStationId()
        {
            return new SuccessDataResult<List<Subpiece>>(_subpieceService.GetByStationId(2), Messages.ProductsListed);
        }

        public IResult Add(Product product, Subpiece subpiece)
        {
            throw new NotImplementedException();
        }
    }
}
