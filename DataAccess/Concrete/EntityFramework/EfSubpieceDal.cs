using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSubpieceDal : EfEntityRepositoryBase<Subpiece, BoschContext>, ISubpieceDal
    {
        public Subpiece GetById(int id)
        {
            using (BoschContext context = new BoschContext())
            {
                return context.Subpiece.FirstOrDefault(s => s.Id == id);
            }
        }
    }
}
