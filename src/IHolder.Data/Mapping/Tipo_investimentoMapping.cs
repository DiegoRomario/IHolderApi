using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class Tipo_investimentoMapping : Informacoes_baseMapping<Tipo_investimento>
    {
        public override void Configure(EntityTypeBuilder<Tipo_investimento> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Risco)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.HasMany(t => t.Distribuicoes_por_tipos_investimentos).WithOne(d => d.Tipo_investimento).HasForeignKey(t => t.Tipo_investimento_id);
            builder.HasMany(t => t.Produtos).WithOne(p => p.Tipo_investimento).HasForeignKey(p => p.Tipo_investimento_id);
            builder.ToTable("Tipo_investimento");
        }
    }
}
