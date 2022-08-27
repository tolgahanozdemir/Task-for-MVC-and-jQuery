﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PurchasePrice { get; set; }
        public float SellingPrice { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public int ShippingId { get; set; }
    }
}
