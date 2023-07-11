using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductSubpiece:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubpieceId { get; set; }
    }
}
