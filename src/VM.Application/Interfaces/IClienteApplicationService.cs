using System;
using System.Collections.Generic;
using VM.Presentation.Application.ViewModels;

namespace VM.Application.Interfaces
{
    public interface IClienteApplicationService : IDisposable
    {
        IEnumerable<ClienteViewModel> ObterTodos();

        IEnumerable<ClienteViewModel> ObterAtivos();

        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteEnderecoViewModel Atualizar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteEnderecoViewModel ObterPor(int id);

        ClienteViewModel ObterClientePor(int id);

        void Remover(int id);
    }
}
