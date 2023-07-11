using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubpieceService
    {
        IDataResult<List<Subpiece>> GetAll();
        IDataResult<Subpiece> GetById(int subpieceId);
        List<Subpiece> GetByStationId(int stationId);
        IResult Add(Subpiece subpiece);
        IResult Update(Subpiece subpiece);
        IResult Delete(Subpiece subpiece);
    }
}
