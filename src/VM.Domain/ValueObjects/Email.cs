using FluentValidation;
using System.Text.RegularExpressions;

namespace VM.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Endereco)
                .Matches(new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"));
        }

        protected override bool EqualsCore(Email other)
        {
            return this.Endereco == other.Endereco;
        }

        protected override int GetHashCodeCore()
        {
            return this.GetHashCode();
        }
    }
}
