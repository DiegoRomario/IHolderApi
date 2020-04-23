using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class Distribuicao_por_ativoMapping : Valores_baseMapping<Distribuicao_por_ativo>
    {
        public override void Configure(EntityTypeBuilder<Distribuicao_por_ativo> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Ativo_id).IsRequired();
            builder.Property(p => p.Data_inclusao).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.ToTable("Distribuicao_por_ativo");

        }
    }
}
