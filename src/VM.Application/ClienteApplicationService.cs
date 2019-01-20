using AutoMapper;
using System;
using System.Collections.Generic;
using VM.Application.Interfaces;
using VM.Domain.Interfaces.Repository;
using VM.Domain.Models;
using VM.Domain.ValueObjects;
using VM.Infra.Data.Interfaces;
using VM.Presentation.Application.ViewModels;

namespace VM.Application
{
    public class ClienteApplicationService : ApplicationService, IClienteApplicationService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteApplicationService(IUnitOfWork uow, IClienteRepository clienteRepository, IMapper mapper) : base(uow)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            var clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());

            return clientes;
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            var clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());

            return clientes;
        }

        public ClienteEnderecoViewModel ObterPor(int id)
        {
            var cliente = _mapper.Map<Cliente>(_clienteRepository.ObterPor(id));

            var clienteEnderecoViewModel = new ClienteEnderecoViewModel();

            clienteEnderecoViewModel.Cliente = _mapper.Map<ClienteViewModel>(cliente);

            clienteEnderecoViewModel.Endereco = _mapper.Map<EnderecoViewModel>(cliente.Endereco);

            return clienteEnderecoViewModel;
        }


        public ClienteViewModel ObterClientePor(int id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(_clienteRepository.ObterPor(id));

            return cliente;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = _mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.AtribuirEndereco(endereco);

            if (cliente.EhValido())
            {
                _clienteRepository.Adicionar(cliente);
                _uow.Commit();
                return clienteEnderecoViewModel;
            }

            clienteEnderecoViewModel.Cliente = _mapper.Map<ClienteViewModel>(cliente);
            clienteEnderecoViewModel.Endereco = _mapper.Map<EnderecoViewModel>(cliente.Endereco);

            return clienteEnderecoViewModel;
        }

        public ClienteEnderecoViewModel Atualizar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = _mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.AtribuirEndereco(endereco);

            if (cliente.EhValido())
            {
                _clienteRepository.Atualizar(cliente);
                _uow.Commit();
                return clienteEnderecoViewModel;
            }

            clienteEnderecoViewModel.Cliente = _mapper.Map<ClienteViewModel>(cliente);
            clienteEnderecoViewModel.Endereco = _mapper.Map<EnderecoViewModel>(cliente.Endereco);

            return clienteEnderecoViewModel;
        }

        public void Remover(int id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
