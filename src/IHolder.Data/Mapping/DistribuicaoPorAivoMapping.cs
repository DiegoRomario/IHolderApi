﻿using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class DistribuicaoPorAivoMapping : IEntityTypeConfiguration<DistribuicaoPorAtivo>
    {
        public void Configure(EntityTypeBuilder<DistribuicaoPorAtivo> builder)
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
            builder.Property(p => p.AtivoId).IsRequired();
            builder.Property(p => p.DataInclusao).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");

            builder.Property(p => p.DistribuicaoPorProdutoId).IsRequired();

            builder.ToTable("DistribuicaoPorAtivo");

        }
    }
}
