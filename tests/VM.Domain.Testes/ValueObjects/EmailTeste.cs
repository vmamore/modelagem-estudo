using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.ValueObjects
{
    public class EmailTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Email_Valido()
        {
            // Arrange
            var email = new Email("vinicius.mamore@gmail.com");

            // Act
            var resultado = email.EhValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Deve_Retornar_False_Para_Email_Invalido()
        {
            // Arrange
            var email = new Email("vinicius.mamoregmail.com.br");

            // Act
            var resultado = email.EhValido();

            // Assert
            Assert.False(resultado);
        }
    }
}
