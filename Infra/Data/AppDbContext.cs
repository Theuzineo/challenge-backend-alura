using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Receitas> tb_Receitas { get; set; }
        public DbSet<Despesas> tb_Despesas { get; set; }
        public DbSet<Usuarios> tb_Usuarios { get; set; }

    }
}
