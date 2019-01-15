using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using VM.Domain.Models;
using VM.Infra.Data.Mapping;

namespace VM.Infra.Data.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) 
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            modelBuilder.Ignore<ValidationResult>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
