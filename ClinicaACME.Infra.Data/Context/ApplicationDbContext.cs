
using ClinicaACME.Domain.Entities;
using ClinicaACME.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext) { }  
        
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
        }
    }
}
