using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Data.Context
{
    public class IHolderContext : DbContext
    {
        public IHolderContext(DbContextOptions<IHolderContext> options)
            : base(options) { }

        public DbSet<Aporte> Aportes { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Distribuicao_por_ativo> Distribuicoes_por_ativos { get; set; }
        public DbSet<Distribuicao_por_produto> Distribuicoes_por_produtos { get; set; }
        public DbSet<Distribuicao_por_tipo_investimento> Distribuicoes_por_tipos_investimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tipo_investimento> Tipos_investimentos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HandleFieldType(modelBuilder, "VARCHAR(100)", typeof(string));
            HandleFieldType(modelBuilder, "DATETIME", typeof(DateTime));
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
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Data_inclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Data_inclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Data_inclusao").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Data_alteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Data_alteracao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Data_alteracao").CurrentValue = DateTime.Now;
                }
            }


            return await base.SaveChangesAsync() > 0;
        }


    }
}
