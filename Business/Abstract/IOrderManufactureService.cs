using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderManufactureService
    {
        IDataResult<List<Subpiece>> GetAllSubpiecesByStationId(int id);
        IResult Add(int orderId, int stationId);
    }
}
