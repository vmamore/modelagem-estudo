using System;
using VM.Domain.Models;
using Xunit;

namespace VM.Domain.Testes.Models
{
    public class ClienteTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Cliente_Valido()
        {
            // Arrange
            var cliente = new Cliente("Vinicius", "Mamoré");
            
            cliente.AtribuirIdade(new DateTime(1997, 10, 25));

            cliente.AtribuirCpf("05599934128");

            cliente.AtribuirEmail("vinicius.mamore@gmail.com");

            // Act
            var resultado = cliente.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Deve_Retornar_False_Para_Cliente_Invalido()
        {
            // Arrange
            var cliente = new Cliente("", "");

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
        }
    }
}
