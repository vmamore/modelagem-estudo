using System;
using System.Collections.Generic;
using System.Text;
using VM.Domain.ValueObjects;
using Xunit;

namespace VM.Domain.Testes.ValueObjects
{
    public class EmailTeste
    {
        [Fact]
        public void Deve_Retornar_True_Para_Email_Valido()
        {
            var email = new Email("vinicius.mamore@gmail.com");

            Assert.True(email.EhValido());
        }

        [Fact]
        public void Deve_Retornar_False_Para_Email_Invalido()
        {
            var email = new Email("vinicius.mamoregmail.com.br");

            Assert.False(email.EhValido());
        }
    }
}
