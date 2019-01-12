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

            builder.Property(c => c.Idade.DataNascimento)
                .IsRequired();

            builder.Property(c => c.Email.Endereco)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(c => c.Endereco.Logradouro)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Endereco.Bairro)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.Endereco.Numero)
                .HasMaxLength(10)
                .IsRequired();
            
            builder.Property(c => c.Endereco.Cidade)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.Endereco.Estado)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Endereco.Complemento)
                .HasMaxLength(200);
            
            builder.Property(c => c.Endereco.Cep.Numero)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
