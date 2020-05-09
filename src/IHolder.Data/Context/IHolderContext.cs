using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Data.Context
{
    public class IHolderContext : DbContext
    {
        public IHolderContext(DbContextOptions<IHolderContext> options)
            : base(options) { }

        public DbSet<Aporte> Aportes { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<DistribuicaoPorAtivo> DistribuicoesPorAtivos { get; set; }
        public DbSet<DistribuicaoPorProduto> DistribuicoesPorProdutos { get; set; }
        public DbSet<DistribuicaoPorTipoInvestimento> DistribuicoesPorTiposInvestimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoInvestimento> TiposInvestimentos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HandleFieldType(modelBuilder, "VARCHAR(100)", typeof(string));
            HandleFieldType(modelBuilder, "DATETIME", typeof(DateTime));
            HandleFieldType(modelBuilder, "DATETIME", typeof(Nullable<DateTime>));
            HandleFieldType(modelBuilder, "DECIMAL(12,2)", typeof(decimal));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IHolderContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        private static void HandleFieldType(ModelBuilder modelBuilder, string sqlFieldType, Type type)
        {
            foreach (var property in modelBuilder
                  .Model
                  .GetEntityTypes()
                  .SelectMany(
                     e => e.GetProperties()
                        .Where(p => p.ClrType == type)))
            {
                property.SetColumnType(sqlFieldType);
            }
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("IncluidoEm") != null && entry.Entity.GetType().GetProperty("AlteradoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("IncluidoEm").CurrentValue = DateTime.Now;
                    entry.Property("AlteradoEm").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("IncluidoEm").IsModified = false;
                    entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }


    }
}
