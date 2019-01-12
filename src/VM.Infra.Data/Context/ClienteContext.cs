using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VM.Domain.Models;
using VM.Infra.Data.Mapping;

namespace VM.Infra.Data.Context
{
    public class ClienteContext : DbContext
    {
        protected ClienteContext()
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
