using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CStationManager
    {
        public IDataResult<List<Subpiece>> GetAllSubpiecesByStationId(int stationId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Product product, Subpiece subpiece)
        {
            throw new NotImplementedException();
        }
    }
}
