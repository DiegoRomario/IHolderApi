using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(r => r.Informacoes.Descricao).IsRequired().HasColumnType("VARCHAR(30)");
            builder.Property(r => r.Informacoes.Caracteristicas).IsRequired().HasColumnType("VARCHAR(240)");
            builder.Property(d => d.TipoInvestimentoId).IsRequired();

            builder.HasMany(p => p.DistribuicoesPorProdutos)
               .WithOne(d => d.Produto)
               .HasForeignKey(d => d.ProdutoId);

            builder.HasMany(p => p.Ativos)
                .WithOne(a => a.Produto)
                .HasForeignKey(a => a.ProdutoId);

            builder.ToTable("Produto");
        }
    }
}
