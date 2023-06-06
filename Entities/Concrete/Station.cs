using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Station: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public Station NextStation { get; set; }
    }
}
