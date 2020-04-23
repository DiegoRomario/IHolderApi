using IHolder.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
            builder.Property(p => p.CPF)
            .IsRequired()
            .HasColumnType("VARCHAR(25)");
            builder.Property(p => p.Celular)
            .IsRequired()
            .HasColumnType("VARCHAR(25)");
            builder.Property(p => p.Data_nascimento)
            .IsRequired();
            builder.Property(p => p.Data_inclusao)
            .IsRequired();
            builder.HasAlternateKey(a => a.CPF);
            builder.HasAlternateKey(a => a.Email);
            builder.HasAlternateKey(a => a.Celular);
            builder.Property(r => r.Genero)
                    .IsRequired()
                    .HasColumnType("TINYINT");

            builder.HasMany(p => p.Distribuicoes_por_tipos_investimentos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.Usuario_id);
            builder.HasMany(p => p.Distribuicoes_por_produtos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.Usuario_id);
            builder.HasMany(p => p.Distribuicoes_por_ativos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.Usuario_id);
            builder.HasMany(p => p.Aportes)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.Usuario_id);
            builder.HasMany(p => p.Ativos)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.Usuario_id);

            builder.HasMany(p => p.Situacoes_por_ativos)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.Usuario_id);

            builder.ToTable("Usuario");
        }
    }
}
