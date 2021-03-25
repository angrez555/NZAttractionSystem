using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NZAttractionSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NZAttractionSystem.Data
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Attraction> Attraction { get; set; }
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options)
            : base(options)
        {
        }
        
      
        public CustomersDbContext()
        {

        }
    }
}
