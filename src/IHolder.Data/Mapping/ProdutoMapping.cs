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
