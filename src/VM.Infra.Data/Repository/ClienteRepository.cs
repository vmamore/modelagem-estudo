using System.Collections.Generic;
using System.Linq;
using VM.Domain.Interfaces.Repository;
using VM.Domain.Models;
using VM.Infra.Data.Context;

namespace VM.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteContext db) : base(db)
        {
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(x => x.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return DbSet.FirstOrDefault(x => x.Cpf.Numero == cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return DbSet.FirstOrDefault(x => x.Email.Endereco == email);
        }
    }
}
