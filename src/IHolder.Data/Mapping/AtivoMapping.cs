using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class AtivoMapping : IEntityTypeConfiguration<Ativo>
    {

        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(r => r.Informacoes.Descricao).IsRequired().HasColumnType("VARCHAR(30)");
            builder.Property(r => r.Informacoes.Caracteristicas).IsRequired().HasColumnType("VARCHAR(240)");
            builder.Property(a => a.Ticker).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(a => a.Cotacao).IsRequired();
            builder.Property(a => a.Risco)
                    .IsRequired()
                    .HasColumnType("TINYINT");
            builder.Property(a => a.ProdutoId).IsRequired();
            builder.Property(p => p.IncluidoEm).IsRequired();
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.HasMany(r => r.DistribuicoesPorAtivos).WithOne(d => d.Ativo).HasForeignKey(d => d.AtivoId);
            builder.HasMany(r => r.Aportes).WithOne(d => d.Ativo).HasForeignKey(d => d.AtivoId);
            builder.HasMany(r => r.SituacoesPorAtivos).WithOne(d => d.Ativo).HasForeignKey(d => d.AtivoId);
            builder.ToTable("Ativo");
        }
    }
}
