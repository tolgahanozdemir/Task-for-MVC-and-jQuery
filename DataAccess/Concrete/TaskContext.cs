﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class TaskContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestProduct;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}