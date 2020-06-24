using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace netcoreWebapi
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() 
            : base("name=DbConnectionString")
        {}

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);
            modelBuilder.Entity<Patient>()
                        .Property(p => p.PatientId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Patient>().Property(p => p.PatientFirstName);
            modelBuilder.Entity<Patient>().Property(p => p.PatientLastName);
            modelBuilder.Entity<Patient>().Property(p => p.PatientWeight);
            modelBuilder.Entity<Patient>().Property(p => p.PatientHeight);

            base.OnModelCreating(modelBuilder);
        }
    }
}
