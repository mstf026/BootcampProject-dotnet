using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Subpiece: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Cost { get; set; }
        public int UniqueNumber { get; set; }
        public int StationId { get; set; }


    }
}
