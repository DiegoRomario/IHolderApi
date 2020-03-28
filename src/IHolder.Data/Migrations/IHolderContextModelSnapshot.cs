﻿// <auto-generated />
using System;
using IHolder.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IHolder.Data.Migrations
{
    [DbContext(typeof(IHolderContext))]
    partial class IHolderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IHolder.Business.Entities.Aporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_aporte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Preco_medio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ativo_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Aporte");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(240)");

                    b.Property<decimal>("Cotacao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int>("Produto_id")
                        .HasColumnType("int");

                    b.Property<int>("Risco_id")
                        .HasColumnType("int");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Produto_id");

                    b.HasIndex("Risco_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Ativo");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Distribuicao_por_ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Orientacao_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentual_atual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentual_diferenca")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentual_objetivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor_atual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor_diferenca")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Ativo_id");

                    b.HasIndex("Orientacao_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Distribuicao_por_ativo");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Distribuicao_por_produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Distribuicao_por_tipo_investimento_id")
                        .HasColumnType("int");

                    b.Property<int>("Orientacao_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentual_atual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentual_diferenca")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentual_objetivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Produto_id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor_atual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor_diferenca")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Distribuicao_por_tipo_investimento_id");

                    b.HasIndex("Orientacao_id");

                    b.HasIndex("Produto_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Distribuicao_por_produto");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Distribuicao_por_tipo_investimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Orientacao_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentual_atual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentual_diferenca")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentual_objetivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipo_investimento_id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor_atual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor_diferenca")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Orientacao_id");

                    b.HasIndex("Tipo_investimento_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Distribuicao_por_tipo_investimento");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Orientacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id");

                    b.ToTable("Orientacao");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int>("Tipo_investimento_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Tipo_investimento_id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Risco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id");

                    b.ToTable("Risco");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Situacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id");

                    b.ToTable("Situacao");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Situacao_por_ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ativo_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("VARCHAR(240)");

                    b.Property<int>("Situacao_id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ativo_id");

                    b.HasIndex("Situacao_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Situacao_por_ativo");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Tipo_investimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int>("Risco_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Risco_id");

                    b.ToTable("Tipo_investimento");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<DateTime?>("Data_alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<byte>("Genero")
                        .HasColumnType("TINYINT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("Senha")
                        .HasColumnType("VARCHAR(240)");

                    b.HasKey("Id");

                    b.HasAlternateKey("CPF");

                    b.HasAlternateKey("Celular");

                    b.HasAlternateKey("Email");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("IHolder.Business.Entities.Aporte", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Ativo", "Ativo")
                        .WithMany("Aportes")
                        .HasForeignKey("Ativo_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Usuario", "Usuario")
                        .WithMany("Aportes")
                        .HasForeignKey("Usuario_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Ativo", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Produto", "Produto")
                        .WithMany("Ativos")
                        .HasForeignKey("Produto_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Risco", "Risco")
                        .WithMany("Ativos")
                        .HasForeignKey("Risco_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Usuario", "Usuario")
                        .WithMany("Ativos")
                        .HasForeignKey("Usuario_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Distribuicao_por_ativo", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Ativo", "Ativo")
                        .WithMany("Distribuicoes_por_ativos")
                        .HasForeignKey("Ativo_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Orientacao", "Orientacao")
                        .WithMany("Distribuicoes_por_ativos")
                        .HasForeignKey("Orientacao_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Usuario", "Usuario")
                        .WithMany("Distribuicoes_por_ativos")
                        .HasForeignKey("Usuario_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Distribuicao_por_produto", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Distribuicao_por_tipo_investimento", "Distribuicao_por_tipo_investimento")
                        .WithMany("Distribuicoes_por_produtos")
                        .HasForeignKey("Distribuicao_por_tipo_investimento_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Orientacao", "Orientacao")
                        .WithMany("Distribuicoes_por_produtos")
                        .HasForeignKey("Orientacao_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Produto", "Produto")
                        .WithMany("Distribuicoes_por_produtos")
                        .HasForeignKey("Produto_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Usuario", "Usuario")
                        .WithMany("Distribuicoes_por_produtos")
                        .HasForeignKey("Usuario_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Distribuicao_por_tipo_investimento", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Orientacao", "Orientacao")
                        .WithMany("Distribuicoes_por_tipos_investimentos")
                        .HasForeignKey("Orientacao_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Tipo_investimento", "Tipo_investimento")
                        .WithMany("Distribuicoes_por_tipos_investimentos")
                        .HasForeignKey("Tipo_investimento_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Usuario", "Usuario")
                        .WithMany("Distribuicoes_por_tipos_investimentos")
                        .HasForeignKey("Usuario_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Produto", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Tipo_investimento", "Tipo_investimento")
                        .WithMany("Produtos")
                        .HasForeignKey("Tipo_investimento_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Situacao_por_ativo", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Ativo", "Ativo")
                        .WithMany("Situacoes_por_ativos")
                        .HasForeignKey("Ativo_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Situacao", "Situacao")
                        .WithMany("Situacoes_por_ativos")
                        .HasForeignKey("Situacao_id")
                        .IsRequired();

                    b.HasOne("IHolder.Business.Entities.Usuario", "Usuario")
                        .WithMany("Situacoes_por_ativos")
                        .HasForeignKey("Usuario_id")
                        .IsRequired();
                });

            modelBuilder.Entity("IHolder.Business.Entities.Tipo_investimento", b =>
                {
                    b.HasOne("IHolder.Business.Entities.Risco", "Risco")
                        .WithMany("Tipos_investimentos")
                        .HasForeignKey("Risco_id")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
