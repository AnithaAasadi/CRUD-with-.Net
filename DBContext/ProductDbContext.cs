﻿using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD.DBContext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }


    }

}
