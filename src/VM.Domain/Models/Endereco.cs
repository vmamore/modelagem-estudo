using FluentValidation;
using FluentValidation.Results;
using VM.Domain.Entities;
using VM.Domain.ValueObjects;

namespace VM.Domain.Models
{
    public class Endereco : Entity<Endereco>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public Cep Cep { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarDados();
            ValidationResult = Validate(this);
        }

        private void ValidarDados()
        {
            RuleFor(e => e.Logradouro)
                .Length(5, 150).WithMessage("Logradouro deve possuir tamanho entre 5 e 150 caracteres")
                .NotEmpty().WithMessage("É necessário informar o logradouro!");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("É necessário informar o número!");


            RuleFor(e => e.Cidade)
                .Length(3, 100).WithMessage("Cidade deve possuir tamanho entre 3 e 100 caracteres")
                .NotEmpty().WithMessage("É necessário informar a cidade!");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("É necessário informar o estado!");

            RuleFor(e => e.Bairro)
                .Length(3, 100).WithMessage("Bairro deve possuir tamanho entre 3 e 100 caracteres")
                .NotEmpty().WithMessage("É necessário informar o bairro!");

            RuleFor(e => e.Cep)
                .NotNull().WithMessage("CEP não pode se vazio!");
        }
    }
}
