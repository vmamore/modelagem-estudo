using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.ValueObjects
{
    public class CepTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Cep_Valido()
        {
            var cep = new Cep("79041210");

            var resultado = cep.EhValido();

            Assert.True(resultado);
        }

        [Fact]
        public void Deve_Retornar_False_Para_Cep_INvalido()
        {
            var cep = new Cep("123456");

            Assert.False(cep.EhValido());
        }
    }
}
