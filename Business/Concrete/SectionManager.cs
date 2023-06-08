using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SectionManager: ISectionService
    {
        private readonly ISectionDal _sectionDal;

        public SectionManager(ISectionDal sectionDal)
        {
            _sectionDal = sectionDal;
        }
        public IDataResult<List<Section>> GetAll()
        {
            return new SuccessDataResult<List<Section>>(_sectionDal.GetAll());
        }

        public IDataResult<Section> GetById(int id)
        {
            return new SuccessDataResult<Section>(_sectionDal.Get(s => s.Id == id));
        }

        public IResult Add(Section section)
        {
            _sectionDal.Add(section);
            return new SuccessResult();
        }
    }
}
