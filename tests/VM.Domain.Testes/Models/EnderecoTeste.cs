using System;
using System.Collections.Generic;
using System.Text;
using VM.Domain.Models;
using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.Models
{
    public class EnderecoTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Endereco_Valido()
        {
            var endereco = new Endereco()
            {
                Logradouro = "Alameda Ipê Amarelo",
                Numero = "100",
                Bairro = "Chácara Cachoeira",
                Cidade = "Campo Grande",
                Estado = "MS",
                Cep = new Cep("79041052")
            };

            Assert.True(endereco.EhValido());
        }

        [Fact]
        public void Deve_Retornar_False_Para_Endereco_Invalido()
        {
            var endereco = new Endereco()
            {
                Logradouro = "",
                Numero = "100",
                Bairro = "Chácara Cachoeira",
                Cidade = "CG",
                Estado = "Mato Grosso do Sul",
                Cep = new Cep("79041052")
            };

            Assert.False(endereco.EhValido());
        }
    }
}
