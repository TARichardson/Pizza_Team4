using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace PizzaAPI.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> _context)
    : base(_context)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CardType> CardType { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            JsonSeed jseed = new JsonSeed();
            // Seed Customer
            List<Customer> customerList = new List<Customer>();
            jseed.LoadSeed("./Data/SeedCustomer.json", ref customerList);
            modelBuilder.Entity<Customer>().HasData(customerList);
            


        }
    }
}


