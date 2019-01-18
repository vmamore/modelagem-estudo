using System;

namespace VM.Presentation.Site.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataDeNascimento { get; set; }
        

    }
}
