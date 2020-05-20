using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class DistribuicaoPorProdutoMapping : IEntityTypeConfiguration<DistribuicaoPorProduto>
    {

        public void Configure(EntityTypeBuilder<DistribuicaoPorProduto> builder)
        {
            builder.HasKey(d => d.Id);
            builder.OwnsOne(a => a.Valores, i =>
            {
                i.Property(a => a.PercentualObjetivo)
                .IsRequired()
                .HasColumnName("PercentualObjetivo");

                i.Property(a => a.PercentualAtual)
                .IsRequired()
                .HasColumnName("PercentualAtual");

                i.Property(a => a.PercentualDiferenca)
                .IsRequired()
                .HasColumnName("PercentualDiferenca");

                i.Property(a => a.ValorAtual)
                .IsRequired()
                .HasColumnName("ValorAtual");

                i.Property(a => a.ValorDiferenca)
                .IsRequired()
                .HasColumnName("ValorDiferenca");
            });
            builder.Property(p => p.DataInclusao).IsRequired();
            builder.Property(p => p.DistribuicaoPorTipoInvestimentoId).IsRequired();
            builder.Property(p => p.ProdutoId).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(p => p.UsuarioId).IsRequired();

            builder.HasMany(d => d.DistribuicoesPorAtivos)
            .WithOne(p => p.DistribuicaoPorProduto)
            .HasForeignKey(p => p.DistribuicaoPorProdutoId);

            builder.ToTable("DistribuicaoPorProduto");
        }
    }
}
