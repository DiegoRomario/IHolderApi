using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class DistribuicaoPorAivoMapping : IEntityTypeConfiguration<DistribuicaoPorAtivo>
    {
        public void Configure(EntityTypeBuilder<DistribuicaoPorAtivo> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(p => p.AtivoId).IsRequired();
            builder.Property(p => p.IncluidoEm).IsRequired();
            builder.Property(p => p.Orientacao)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.ToTable("Distribuicao_por_ativo");

        }
    }
}
