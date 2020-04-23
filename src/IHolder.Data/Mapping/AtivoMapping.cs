using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class AtivoMapping : Informacoes_baseMapping<Ativo>
    {

        public override void Configure(EntityTypeBuilder<Ativo> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.Ticker).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(a => a.Cotacao).IsRequired();
            builder.Property(a => a.Risco)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(a => a.Produto_id).IsRequired();
            builder.Property(p => p.Data_inclusao).IsRequired();
            builder.Property(p => p.Usuario_id).IsRequired();
            builder.HasMany(r => r.Distribuicoes_por_ativos).WithOne(d => d.Ativo).HasForeignKey(d => d.Ativo_id);
            builder.HasMany(r => r.Aportes).WithOne(d => d.Ativo).HasForeignKey(d => d.Ativo_id);
            builder.HasMany(r => r.Situacoes_por_ativos).WithOne(d => d.Ativo).HasForeignKey(d => d.Ativo_id);
            builder.ToTable("Ativo");
        }
    }
}
