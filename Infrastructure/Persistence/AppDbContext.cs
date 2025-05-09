using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients")
                    .HasKey(client => client.CUIT);
                    
                entity.Property(client => client.CUIT)
                    .HasMaxLength(11)
                    .IsRequired();

                entity.Property(client => client.Telefono)
                    .HasMaxLength(20);
                
                entity.Property(c => c.Direccion)
                    .HasMaxLength(200);
            });
        }
    }
}
