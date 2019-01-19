using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.ValueObjects
{
    public class CepTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Cep_Valido()
        {
            // Arrange
            var cep = new Cep("79041210");

            // Act
            var resultado = cep.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Deve_Retornar_False_Para_Cep_INvalido()
        {
            // Arrange
            var cep = new Cep("123456");

            // Act
            var resultado = cep.EhValido();

            // Assert
            Assert.False(resultado);
        }
    }
}
