﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VM.Infra.Data.Context;

namespace VM.Infra.Data.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20190119043033_Ajuste_De_Colunas_Date")]
    partial class Ajuste_De_Colunas_Date
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VM.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("VM.Domain.Models.Cliente", b =>
                {
                    b.OwnsOne("VM.Domain.ValueObjects.CPF", "Cpf", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Cpf")
                                .HasMaxLength(11);

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.HasOne("VM.Domain.Models.Cliente")
                                .WithOne("Cpf")
                                .HasForeignKey("VM.Domain.ValueObjects.CPF", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("VM.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(300);

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.HasOne("VM.Domain.Models.Cliente")
                                .WithOne("Email")
                                .HasForeignKey("VM.Domain.ValueObjects.Email", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("VM.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnName("Bairro")
                                .HasMaxLength(100);

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnName("Complemento")
                                .HasMaxLength(200);

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnName("Estado")
                                .HasMaxLength(2);

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("Logradouro")
                                .HasMaxLength(150);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Numero")
                                .HasMaxLength(10);

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.HasOne("VM.Domain.Models.Cliente")
                                .WithOne("Endereco")
                                .HasForeignKey("VM.Domain.ValueObjects.Endereco", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("VM.Domain.ValueObjects.Cep", "Cep", b2 =>
                                {
                                    b2.Property<int>("EnderecoClienteId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Numero")
                                        .IsRequired()
                                        .HasColumnName("Cep")
                                        .HasMaxLength(8);

                                    b2.HasKey("EnderecoClienteId");

                                    b2.ToTable("Clientes");

                                    b2.HasOne("VM.Domain.ValueObjects.Endereco")
                                        .WithOne("Cep")
                                        .HasForeignKey("VM.Domain.ValueObjects.Cep", "EnderecoClienteId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("VM.Domain.ValueObjects.Idade", "Idade", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("DataNascimento")
                                .HasColumnName("DataNascimento")
                                .HasColumnType("date");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.HasOne("VM.Domain.Models.Cliente")
                                .WithOne("Idade")
                                .HasForeignKey("VM.Domain.ValueObjects.Idade", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}