using APIExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace APIExamen.Core.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("DefaultConnection");
            }
        }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<SubMarca> SubMarca { get; set; }
        public DbSet<ModeloSubMarca> ModeloSubMarca { get; set; }
        public DbSet<Descripcion> Descripcion { get; set; }
    }
}
