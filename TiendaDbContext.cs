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
            modelBuilder.Entity<Categoria>().ToTable("Categoria").HasKey(c => new { c.CategoriaId });
            modelBuilder.Entity<Producto>().HasOne(p => p.Categoria).WithMany(c => c.Productos).HasForeignKey(p => p.CategoriaId);
        }
    }
}