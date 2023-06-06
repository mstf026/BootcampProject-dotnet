using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SubpieceManager : ISubpieceService
    {
        private readonly ISubpieceDal _subpieceDal;
        public SubpieceManager(ISubpieceDal subpieceDal)
        {
            _subpieceDal = subpieceDal;
        }

        public List<Subpiece> GetByStationId(int stationId)
        {
            return new List<Subpiece>(_subpieceDal.GetAll(s => s.StationId == stationId));
        }

        public IResult Add(Subpiece subpiece)
        {
            if (subpiece.Name.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _subpieceDal.Add(subpiece);

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Subpiece>> GetAll()
        {
            return new SuccessDataResult<List<Subpiece>>(_subpieceDal.GetAll());
        }

        public IDataResult<Subpiece> GetById(int subpieceId)
        {
            return new SuccessDataResult<Subpiece>(_subpieceDal.Get(s => s.Id == subpieceId));
        }
    }
}
