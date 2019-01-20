using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using VM.Application.Interfaces;
using VM.Domain.Models;
using VM.Presentation.Application.ViewModels;

namespace VM.Presentation.Site.Controllers
{
    [Route("")]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteApplicationService _clienteAppService;

        public ClientesController(IClienteApplicationService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("")]
        [Route("inicio")]
        public IActionResult Index()
        {
            var clientes = _clienteAppService.ObterTodos();

            return View(clientes);
        }

        [HttpGet("detalhes/{id}")]
        public IActionResult Detalhes(int id)
        {
            var clienteEnderecoViewModel = _clienteAppService.ObterPor(id);

            return View(clienteEnderecoViewModel);
        }

        [HttpGet("criar")]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost("criar")]
        public IActionResult Criar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var clienteRetorno = _clienteAppService.Adicionar(clienteEnderecoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
        {
            var cliente = _clienteAppService.ObterPor(id);

            return View(cliente);
        }

        [HttpPost("editar/{id}")]
        public IActionResult Editar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
           var clienteRetorno = _clienteAppService.Atualizar(clienteEnderecoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("remover/{id}")]
        public IActionResult Remover(int id)
        {
            var cliente = _clienteAppService.ObterClientePor(id);

            return View(cliente);
        }

        [HttpPost("remover/{id}")]
        public IActionResult RemoverCliente(int id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }
        
        private void AdicionarErros(IList<ValidationFailure> errors)
        {
            foreach (var erro in errors)
                ModelState.AddModelError("", erro.ErrorMessage);
        }
    }
}