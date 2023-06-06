﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ModelNumber { get; set; }
        public string Type { get; set; }
        //public List<Subpiece> Subpieces { get; set; }
        //public Product()
        //{
        //    Subpieces = new List<Subpiece>();
        //}


    }
}
