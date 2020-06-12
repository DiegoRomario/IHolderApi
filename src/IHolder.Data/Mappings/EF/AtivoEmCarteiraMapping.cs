using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class AtivoEmCarteiraMapping : IEntityTypeConfiguration<AtivoEmCarteira>
    {
        public void Configure(EntityTypeBuilder<AtivoEmCarteira> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(p => p.AtivoId).IsRequired();
            builder.Property(p => p.PrecoMedio).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.Property(p => p.DataInclusao).IsRequired();
            builder.Property(p => p.DataPrimeiroAporte).IsRequired();
            builder.ToTable("AtivoEmCarteira");

        }
    }
}
