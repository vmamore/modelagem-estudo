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
                .IsRequired();
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .HasMaxLength(300)
                    .IsRequired();
            });

            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.Logradouro)
                    .HasMaxLength(150)
                    .IsRequired();

                endereco.Property(e => e.Bairro)
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsRequired();

                endereco.Property(e => e.Cidade)
                    .HasMaxLength(100)
                    .IsRequired();

                endereco.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsRequired();

                endereco.Property(e => e.Complemento)
                    .HasMaxLength(200);

                endereco.OwnsOne(c => c.Cep, cep =>
                {

                    cep.Property(c => c.Numero)
                        .HasMaxLength(8)
                        .IsRequired();
                });
            });


            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.Numero)
                .HasMaxLength(11)
                .IsRequired();
            });

            builder.Ignore(c => c.ValidationResult);
            
            builder.Ignore(c => c.CascadeMode);
        }
    }
}
