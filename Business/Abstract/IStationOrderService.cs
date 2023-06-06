using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStationOrderService
    {
        IDataResult<List<Subpiece>> GetAllSubpiecesByStationId();
        IResult Add(Product product, Subpiece subpiece);
    }
}
