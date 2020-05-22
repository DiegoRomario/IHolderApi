using IHolder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHolder.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(80)");
            builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(40)");
            builder.Property(p => p.Senha)
            .HasColumnType("VARCHAR(240)");
            builder.Property(p => p.DataInclusao)
            .IsRequired();
            builder.HasAlternateKey(a => a.Email);
            builder.Property(r => r.Genero)
                    .IsRequired()
                    .HasColumnType("TINYINT");

            builder.HasMany(p => p.DistribuicoesPorTiposInvestimentos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId);
            builder.HasMany(p => p.DistribuicoesPorProdutos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId);
            builder.HasMany(p => p.DistribuicoesPorAtivos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId);
            builder.HasMany(p => p.Aportes)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId);
            builder.HasMany(p => p.Ativos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId);

            builder.ToTable("Usuario");
        }
    }
}
