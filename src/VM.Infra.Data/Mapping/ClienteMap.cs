using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VM.Domain.Models;

namespace VM.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Sobrenome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired(); ;

            builder.OwnsOne(c => c.Idade, idade =>
            {
                idade.Property(i => i.DataNascimento)
                    .HasColumnName("DataNascimento")
                    .IsRequired();

                idade.Ignore(i => i.CascadeMode);
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .HasColumnName("Email")
                    .HasMaxLength(300)
                    .IsRequired();

                email.Ignore(e => e.CascadeMode);
            });

            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasMaxLength(150)
                    .IsRequired();

                endereco.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Numero)
                    .HasColumnName("Numero")
                    .HasMaxLength(10)
                    .IsRequired();

                endereco.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Estado)
                    .HasColumnName("Estado")
                    .HasMaxLength(2)
                    .IsRequired();

                endereco.Property(e => e.Complemento)
                    .HasColumnName("Complemento")
                    .HasMaxLength(200);

                endereco.Ignore(e => e.CascadeMode);

                endereco.OwnsOne(c => c.Cep, cep =>
                {
                    cep.Property(c => c.Numero)
                        .HasColumnName("Cep")
                        .HasMaxLength(8)
                        .IsRequired();

                    cep.Ignore(c => c.CascadeMode);
                });
            });


            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.Numero)
                    .HasColumnName("Cpf")
                    .HasMaxLength(11)
                    .IsRequired();

                cpf.Ignore(c => c.CascadeMode);
            });

            builder.Ignore(c => c.ValidationResult);
            
            builder.Ignore(c => c.CascadeMode);
        }
    }
}
