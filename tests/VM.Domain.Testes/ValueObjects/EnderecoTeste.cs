
using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.ValueObjects
{
    public class EnderecoTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Endereco_Valido()
        {
            // Arrange
            var endereco = new Endereco("Alameda Ipê Amarelo", "100", "Campo Grande", "MS", "Chácara Cachoeira", "", "79041052");

            // Act
            var resultado = endereco.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Deve_Retornar_False_Para_Endereco_Invalido()
        {
            // Arrange
            var endereco = new Endereco("", "100", "Campo Grande", "MS", "Chácara Cachoeira", "", "79041052");

            // Act
            var resultado = endereco.EhValido();

            // Assert
            Assert.False(resultado);
        }
    }
}
