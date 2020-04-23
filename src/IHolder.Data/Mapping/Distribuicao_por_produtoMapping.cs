using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Mapping
{
    public class Distribuicao_por_produtoMapping : Valores_baseMapping<Distribuicao_por_produto>
    {

        public override void Configure(EntityTypeBuilder<Distribuicao_por_produto> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Data_inclusao).IsRequired();
            builder.Property(p => p.Distribuicao_por_tipo_investimento_id).IsRequired();
            builder.Property(p => p.Produto_id).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(p => p.Usuario_id).IsRequired();
            builder.ToTable("Distribuicao_por_produto");
        }
    }
}
