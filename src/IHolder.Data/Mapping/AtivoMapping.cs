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



            builder.Property(a => a.Ticker).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(a => a.Cotacao).IsRequired();
            builder.Property(a => a.ProdutoId).IsRequired();
            builder.Property(p => p.DataInclusao).IsRequired();
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.Property(p => p.Situacao)
                    .HasColumnType("TINYINT");
            builder.HasMany(r => r.DistribuicoesPorAtivos).WithOne(d => d.Ativo).HasForeignKey(d => d.AtivoId);
            builder.HasMany(r => r.Aportes).WithOne(d => d.Ativo).HasForeignKey(d => d.AtivoId);
            builder.ToTable("Ativo");
        }
    }
}
