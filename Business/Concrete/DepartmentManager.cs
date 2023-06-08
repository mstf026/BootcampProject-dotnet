using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public IResult Add(Department department)
        {
            if (department.Name.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _departmentDal.Add(department);

            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Department department)
        {
            if (department.Name.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _departmentDal.Update(department);

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll());
        }

        public IDataResult<Department> GetById(int departmentId)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(s => s.Id == departmentId));
        }
    }
}
