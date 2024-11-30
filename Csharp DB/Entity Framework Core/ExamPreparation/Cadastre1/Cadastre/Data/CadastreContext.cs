namespace Cadastre.Data
{
    using Cadastre.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

    public class CadastreContext : DbContext
    {
        public CadastreContext()
        {
            
        }

        public CadastreContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public  DbSet<District> Districts { get; set; }
        public  DbSet<Citizen> Citizens { get; set; }
        public  DbSet<Property> Properties { get; set; }
        public  DbSet<PropertyCitizen> PropertiesCitizens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyCitizen>(entity =>
            {
                entity.HasKey(e => new { e.PropertyId, e.CitizenId });
            });
        }
    }
}
