using E_Commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace E_Commerce_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options) { }




        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
