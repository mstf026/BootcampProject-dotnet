using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStationService
    {
        IDataResult<List<Station>> GetAll();
        IDataResult<Station> GetById(int id);
        IResult Add(Station station);

    }
}
