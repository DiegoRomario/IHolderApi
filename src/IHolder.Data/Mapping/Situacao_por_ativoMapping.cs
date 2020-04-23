using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class Situacao_por_ativoMapping : IEntityTypeConfiguration<Situacao_por_ativo>
    {
        public void Configure(EntityTypeBuilder<Situacao_por_ativo> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Ativo_id).IsRequired();
            builder.Property(s => s.Usuario_id).IsRequired();
            builder.Property(s => s.Data_inclusao).IsRequired();
            builder.Property(s => s.Situacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(s => s.Observacao).HasColumnType("VARCHAR(240)");
            builder.ToTable("Situacao_por_ativo");
        }
    }
}
