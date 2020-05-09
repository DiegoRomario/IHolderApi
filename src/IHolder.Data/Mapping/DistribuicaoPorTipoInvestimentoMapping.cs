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
            builder.Property(d => d.TipoInvestimentoId).IsRequired();
            builder.Property(d => d.UsuarioId).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.HasMany(d => d.DistribuicoesPorProdutos)
                .WithOne(p => p.DistribuicaoPorTipoInvestimento)
                .HasForeignKey(p => p.DistribuicaoPorTipoInvestimentoId);
            builder.Property(p => p.DataInclusao).IsRequired();

            builder.ToTable("DistribuicaoPorTipoInvestimento");
        }        
    }
}
