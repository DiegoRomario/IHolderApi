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
            builder.Property(p => p.IncluidoEm).IsRequired();
            builder.Property(p => p.DistribuicaoPorTipoInvestimentoId).IsRequired();
            builder.Property(p => p.ProdutoId).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.ToTable("Distribuicao_por_produto");
        }
    }
}
