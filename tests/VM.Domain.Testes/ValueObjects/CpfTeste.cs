using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.ValueObjects
{
    public class CpfTeste
    {
        [Theory]
        [InlineData("98877385065")]
        [InlineData("61291950010")]
        [InlineData("53251356003")]
        public void Deve_Retornar_True_Para_Cpf_Valido(string cpfNumero) {

            // Arrange
            var cpf = new CPF(cpfNumero);

            // Act
            var resultado = cpf.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData("37668412030")]
        [InlineData("49862524029")]
        [InlineData("0499681606")]
        public void Deve_Retornar_False_Para_Cpf_Invalido(string cpfNumero)
        {
            // Arrange
            var cpf = new CPF(cpfNumero);

            // Act
            var resultado = cpf.EhValido();

            // Assert
            Assert.False(resultado);
        }
    }
}
