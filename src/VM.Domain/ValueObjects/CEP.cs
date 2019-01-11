using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace VM.Domain.ValueObjects
{
    public class Cep : ValueObject<Cep>
    {
        public string Numero { get; private set; }

        public string NumeroFormatado
        {
            get
            {
                return string.Format("{0}-{1}", this.Numero.Substring(0, 5), this.Numero.Substring(5));
            }
        }

        public Cep(string numero)
        {
            Numero = numero;
        }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Numero)
                .Length(8).WithMessage("CEP deve possuir 8 caracteres!");

            RuleFor(x => x.NumeroFormatado)
                .Matches(new Regex("[0-9]{5}-[0-9]{3}")).WithMessage("CEP com formato inválido!");   
        }
        
        protected override bool EqualsCore(Cep other)
        {
            return this.Numero == other.Numero;
        }

        protected override int GetHashCodeCore()
        {
            return Numero.GetHashCode();
        }
    }
}
