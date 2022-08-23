﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        void BulkAdd(List<Product> product);
        void Add(Product product);
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
    }
}
