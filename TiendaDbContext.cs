using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi
{
    public class TiendaDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public TiendaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Producto").HasKey(p => new { p.ProductoId });
        }
    }
}