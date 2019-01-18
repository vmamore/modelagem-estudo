using Microsoft.AspNetCore.Mvc;
using VM.Domain.Interfaces.Repository;
using VM.Domain.Models;
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

            var clienteViewModel = new ClienteViewModel() {
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                DataCadastro = cliente.DataCadastro,
                DataDeNascimento = cliente.Idade.DataNascimento,
                Ativo = cliente.Ativo
            };
            
            return View(clienteViewModel);
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