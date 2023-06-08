using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProduct_SubpieceService
    {
        IDataResult<List<Product_Subpiece>> GetAll();
        IDataResult<List<Product_Subpiece>> GetByProductId(int productId);
        IResult Add(Product_Subpiece productSubpiece);
    }
}
