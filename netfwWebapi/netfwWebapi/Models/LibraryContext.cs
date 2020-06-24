using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace netfwWebapi.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=DbConnectionString")
        { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
            modelBuilder.Entity<Customer>()
                        .Property(p => p.CustomerId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(p => p.FirstName);
            modelBuilder.Entity<Customer>().Property(p => p.LastName);
            modelBuilder.Entity<Customer>().Property(p => p.SocialInsuranceNumber);
            modelBuilder.Entity<Customer>().Property(p => p.Ssn);

            base.OnModelCreating(modelBuilder);
        }
    }
}