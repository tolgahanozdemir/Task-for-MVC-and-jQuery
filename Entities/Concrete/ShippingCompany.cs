﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShippingCompany : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}