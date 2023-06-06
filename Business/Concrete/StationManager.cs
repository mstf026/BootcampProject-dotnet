using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StationManager : IStationService
    {
        private readonly IStationDal _stationDal;

        public StationManager(IStationDal stationDal)
        {
            _stationDal = stationDal;
        }

        public IResult Add(Station station)
        {
            _stationDal.Add(station);
            return new SuccessDataResult<Station>(Messages.Added);
        }

        public IDataResult<List<Station>> GetAll()
        {
            return new SuccessDataResult<List<Station>>(_stationDal.GetAll());
        }

        public IDataResult<Station> GetById(int id)
        {
            return new SuccessDataResult<Station>(_stationDal.Get(s=>s.Id == id));
        }

    }
}
