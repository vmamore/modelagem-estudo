using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using VM.Domain.Interfaces.Repository;
using VM.Domain.Models;
using VM.Domain.ValueObjects;
using VM.Presentation.Site.ViewModels;

namespace VM.Presentation.Site.Controllers
{
    [Route("")]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [Route("")]
        [Route("inicio")]
        public IActionResult Index()
        {
            var clientes = _clienteRepository.ObterTodos();

            return View(clientes);
        }

        [HttpGet("detalhes/{id}")]
        public IActionResult Detalhes(int id)
        {
            var cliente = _clienteRepository.ObterPor(id);

            var clienteViewModel = new ClienteViewModel()
            {
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                DataCadastro = cliente.DataCadastro,
                DataDeNascimento = cliente.Idade.DataNascimento,
                Ativo = cliente.Ativo
            };

            return View(clienteViewModel);
        }

        [HttpGet("criar")]
        public IActionResult Criar()
        {
            var clienteEnderecoViewModel = new ClienteEnderecoViewModel();

            return View(clienteEnderecoViewModel);
        }

        [HttpPost("criar")]
        public IActionResult Criar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = new Cliente(clienteEnderecoViewModel.Cliente.Nome, clienteEnderecoViewModel.Cliente.Sobrenome);

            cliente.AtribuirIdade(clienteEnderecoViewModel.Cliente.DataDeNascimento);

            cliente.AtribuirEmail(clienteEnderecoViewModel.Cliente.Email);

            cliente.AtribuirCpf(clienteEnderecoViewModel.Cliente.CPF);

            cliente.AtribuirEndereco(
                clienteEnderecoViewModel.Endereco.Logradouro,
                clienteEnderecoViewModel.Endereco.Numero,
                clienteEnderecoViewModel.Endereco.Cidade,
                clienteEnderecoViewModel.Endereco.Estado,
                clienteEnderecoViewModel.Endereco.Bairro,
                clienteEnderecoViewModel.Endereco.Complemento,
                clienteEnderecoViewModel.Endereco.Cep);

            if (!cliente.EhValido())
            {
                AdicionarErros(cliente.ValidationResult.Errors);
                return View(clienteEnderecoViewModel);
            }
            
            _clienteRepository.Adicionar(cliente);

            _clienteRepository.Salvar();

            return RedirectToAction("Index");
        }

        private void AdicionarErros(IList<ValidationFailure> errors)
        {
            foreach (var erro in errors)
                ModelState.AddModelError("", erro.ErrorMessage);
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
        {
            var cliente = _clienteRepository.ObterPor(id);

            var clienteViewModel = new ClienteViewModel()
            {
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                DataCadastro = cliente.DataCadastro,
                DataDeNascimento = cliente.Idade.DataNascimento,
                Ativo = cliente.Ativo
            };

            return View(clienteViewModel);
        }

        [HttpPost("editar/{id}")]
        public IActionResult Editar(ClienteViewModel clienteViewModel)
        {
            return RedirectToAction("Index");
        }

        [HttpGet("remover/{id}")]
        public IActionResult Remover(int id)
        {
            var cliente = _clienteRepository.ObterPor(id);

            var clienteViewModel = new ClienteViewModel()
            {
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                DataCadastro = cliente.DataCadastro,
                DataDeNascimento = cliente.Idade.DataNascimento,
                Ativo = cliente.Ativo
            };

            return View(clienteViewModel);
        }

        [HttpPost("remover/{id}")]
        public IActionResult RemoverCliente(int id)
        {
            var cliente = _clienteRepository.ObterPor(id);

            cliente.Inativar();

            _clienteRepository.Atualizar(cliente);

            _clienteRepository.Salvar();

            return RedirectToAction("Index");
        }
    }
}