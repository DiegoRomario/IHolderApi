using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class Distribuicao_por_tipo_investimentoMapping : Valores_baseMapping<Distribuicao_por_tipo_investimento>
    {
        public override void Configure(EntityTypeBuilder<Distribuicao_por_tipo_investimento> builder)
        {
            base.Configure(builder);
            builder.Property(d => d.Tipo_investimento_id).IsRequired();
            builder.Property(d => d.Usuario_id).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.HasMany(d => d.Distribuicoes_por_produtos)
                .WithOne(p => p.Distribuicao_por_tipo_investimento)
                .HasForeignKey(p => p.Distribuicao_por_tipo_investimento_id);
            builder.Property(p => p.Data_inclusao).IsRequired();

            builder.ToTable("Distribuicao_por_tipo_investimento");
        }        
    }
}
