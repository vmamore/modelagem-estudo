using System;
using VM.Domain.Models;
using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.Models
{
    public class ClienteTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Cliente_Valido()
        {
            var cliente = new Cliente
            {
                Nome = "Vinícius",
                Sobrenome = "Mamoré",
                DataCadastro = DateTime.Now,
                Idade = new Idade(new DateTime(1997, 10, 25)),
                Cpf = new CPF(),
                Email = new Email("vinicius.mamore@gmail.com")
            };

            Assert.True(cliente.EhValido());
        }

        [Fact]
        public void Deve_Retornar_False_Para_Cliente_Invalido()
        {
            var cliente = new Cliente
            {
                Nome = "",
                Sobrenome = "",
                DataCadastro = DateTime.Now
            };

            var result = cliente.EhValido();

            Assert.False(result);
        }
    }
}
