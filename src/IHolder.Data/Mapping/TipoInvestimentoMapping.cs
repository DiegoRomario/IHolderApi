using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace IHolder.Data.Mapping
{
    public class TipoInvestimentoMapping : IEntityTypeConfiguration<TipoInvestimento>
    {
        public void Configure(EntityTypeBuilder<TipoInvestimento> builder)
        {
            builder.HasKey(a => a.Id);
            builder.OwnsOne(a => a.Informacoes, i =>
            {
                i.Property(a => a.Descricao)
                            .IsRequired()
                            .HasColumnName("Descricao")
                            .HasColumnType("VARCHAR(30)");

                i.Property(c => c.Caracteristicas)
                            .IsRequired()
                            .HasColumnName("Caracteristicas")
                            .HasColumnType("VARCHAR(240)");
            });
            builder.Property(t => t.Risco)
            .IsRequired()
            .HasColumnType("TINYINT");
            builder.HasMany(t => t.DistribuicoesPorTiposInvestimentos).WithOne(d => d.TipoInvestimento).HasForeignKey(t => t.TipoInvestimentoId);
            builder.HasMany(t => t.Produtos).WithOne(p => p.TipoInvestimento).HasForeignKey(p => p.TipoInvestimentoId);
            builder.ToTable("TipoInvestimento");
        }
    }
}
