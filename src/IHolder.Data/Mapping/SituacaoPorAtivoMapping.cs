using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class SituacaoPorAtivoMapping : IEntityTypeConfiguration<SituacaoPorAtivo>
    {
        public void Configure(EntityTypeBuilder<SituacaoPorAtivo> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.AtivoId).IsRequired();
            builder.Property(s => s.UsuarioId).IsRequired();
            builder.Property(s => s.DataInclusao).IsRequired();
            builder.Property(s => s.Situacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(s => s.Observacao).HasColumnType("VARCHAR(240)");
            builder.ToTable("SituacaoPorAtivo");
        }
    }
}
