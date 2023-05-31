using apiBancario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiBancario.Models
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<Cliente>()
            .Property(c => c.Saldo)
            .HasColumnType("decimal(18,2)");

            // Outras configurações do modelo

            base.OnModelCreating(modelBuilder);
            // Configurações adicionais para o modelo, se necessário
        }
    }
}
