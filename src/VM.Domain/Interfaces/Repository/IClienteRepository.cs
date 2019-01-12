using System;
using System.Collections.Generic;
using System.Text;
using VM.Domain.Models;

namespace VM.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}
