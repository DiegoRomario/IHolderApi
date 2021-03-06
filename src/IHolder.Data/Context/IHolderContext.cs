﻿using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Data.Context
{
    public class IHolderContext : DbContext, IUnitOfWork
    {
        public IHolderContext(DbContextOptions<IHolderContext> options) : base(options) { }

        public DbSet<AtivoEmCarteira> AtivosEmCarteira { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<DistribuicaoPorAtivo> DistribuicoesPorAtivos { get; set; }
        public DbSet<DistribuicaoPorProduto> DistribuicoesPorProdutos { get; set; }
        public DbSet<DistribuicaoPorTipoInvestimento> DistribuicoesPorTiposInvestimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoInvestimento> TiposInvestimentos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FieldTypeHandler(modelBuilder, "VARCHAR(100)", typeof(string));
            FieldTypeHandler(modelBuilder, "DATETIME", typeof(DateTime));
            FieldTypeHandler(modelBuilder, "DATETIME", typeof(Nullable<DateTime>));
            FieldTypeHandler(modelBuilder, "DECIMAL(12,2)", typeof(decimal));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IHolderContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        private static void FieldTypeHandler(ModelBuilder modelBuilder, string sqlFieldType, Type type)
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
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInclusao") != null && entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                    entry.Property("DataAlteracao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInclusao").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }


    }
}
