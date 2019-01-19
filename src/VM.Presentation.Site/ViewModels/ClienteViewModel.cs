using System;
using System.ComponentModel.DataAnnotations;

namespace VM.Presentation.Site.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public bool Ativo { get; set; }
        
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        public DateTime DataCadastro { get; set; }



    }
}
