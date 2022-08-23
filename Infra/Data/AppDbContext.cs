using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Despesas>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Despesas)
                .HasForeignKey(d => d.UsuarioID);

            modelBuilder.Entity<Receitas>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Receitas)
                .HasForeignKey(d => d.UsuarioID);

            //modelBuilder.Entity<Usuarios>()
            //    .HasMany(d => d.Despesas)
            //    .WithOne(u => u.Usuario)
                
        }

        public DbSet<Receitas> tb_Receitas { get; set; }
        public DbSet<Despesas> tb_Despesas { get; set; }
        public DbSet<Usuarios> tb_Usuarios { get; set; }

    }
}
