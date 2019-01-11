using FluentValidation;
using System;

namespace VM.Domain.ValueObjects
{
    public class Idade : ValueObject<Idade>
    {
        public DateTime DataNascimento { get; private set; }

        public int AnosDeIdade { get { return DateTime.Now.Year - DataNascimento.Year; } }

        public Idade(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public override bool EhValido()
        {
            Validar();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage("É necessário informar data de nascimento");
        }

        protected override bool EqualsCore(Idade other)
        {
            return this.DataNascimento == other.DataNascimento;
        }

        protected override int GetHashCodeCore()
        {
            return this.DataNascimento.GetHashCode();
        }
    }
}
