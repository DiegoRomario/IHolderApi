using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class DistribuicaoPorTipoInvestimentoMapping : IEntityTypeConfiguration<DistribuicaoPorTipoInvestimento>
    {
        public void Configure(EntityTypeBuilder<DistribuicaoPorTipoInvestimento> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.TipoInvestimentoId).IsRequired();
            builder.Property(d => d.UsuarioId).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.HasMany(d => d.DistribuicoesPorProdutos)
                .WithOne(p => p.DistribuicaoPorTipoInvestimento)
                .HasForeignKey(p => p.DistribuicaoPorTipoInvestimentoId);
            builder.Property(p => p.IncluidoEm).IsRequired();

            builder.ToTable("Distribuicao_por_tipo_investimento");
        }        
    }
}
