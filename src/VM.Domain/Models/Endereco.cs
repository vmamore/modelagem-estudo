using FluentValidation;
using FluentValidation.Results;
using VM.Domain.Entities;
using VM.Domain.ValueObjects;

namespace VM.Domain.Models
{
    public class Endereco : ValueObject<Endereco>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public Cep Cep { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        protected override bool EqualsCore(Endereco other)
        {
            return this.Logradouro == other.Logradouro
                && this.Numero == other.Numero
                && this.Cidade == other.Cidade
                && this.Estado == other.Estado
                && this.Bairro == other.Bairro
                && this.Complemento == other.Complemento
                && this.Cep.Numero == other.Cep.Numero;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = this.Logradouro.GetHashCode();

                hashCode = (hashCode * 397) ^ this.Numero.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Cidade.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Estado.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Bairro.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Complemento.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Cep.Numero.GetHashCode();
                
                return hashCode;
            }
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
                .MaximumLength(10).WithMessage("O campo Numero é no máximo de 10 caracteres!")
                .NotEmpty().WithMessage("É necessário informar o número!");
            
            RuleFor(e => e.Cidade)
                .Length(3, 100).WithMessage("Cidade deve possuir tamanho entre 3 e 100 caracteres")
                .NotEmpty().WithMessage("É necessário informar a cidade!");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("É necessário informar o estado!");

            RuleFor(e => e.Bairro)
                .Length(3, 100).WithMessage("Bairro deve possuir tamanho entre 3 e 100 caracteres")
                .NotEmpty().WithMessage("É necessário informar o bairro!");

            RuleFor(e => e.Complemento)
                .MaximumLength(200).WithMessage("O campo Complemento é no máximo de 300 caracteres!");

            RuleFor(e => e.Cep)
                .NotNull().WithMessage("CEP não pode se vazio!");
        }
    }
}
