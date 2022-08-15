using BackEnd_Challenge_Alura.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Challenge_Alura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { base.OnModelCreating(modelBuilder); }

        public DbSet<Receitas> ReceitasDb { get; set; }
        public DbSet<Despesas> DespesasDb { get; set; }

    }
}
