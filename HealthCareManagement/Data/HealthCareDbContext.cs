using HealthCareManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareManagement.Data
{
    public class HealthCareDbContext : DbContext
    {
        public HealthCareDbContext()
        {
        }

        public HealthCareDbContext(DbContextOptions<HealthCareDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);
                entity.ToTable("Patient");

                entity.Property(e => e.PatientName).HasColumnName("Patient_Name");
            });
        }
    }
}
