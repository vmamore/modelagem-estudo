using System;
using FluentValidation;
using FluentValidation.Results;
using VM.Domain.Entities;
using VM.Domain.ValueObjects;

namespace VM.Domain.ValueObjects
{
    public class Endereco : ValueObject<Endereco>
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public Cep Cep { get; private set; }

        public Endereco(string logradouro, string numero, string cidade, string estado, string bairro, string complemento, string cepNumero)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Bairro = bairro;
            Complemento = complemento;

            AtribuirCep(cepNumero);
            // TODO: Adicionar algum erro caso esteja invalido
        }

        private bool AtribuirCep(string cepNumero)
        {
            var cep = new Cep(cepNumero);

            if (!cep.EhValido())
                return false;

            this.Cep = cep;
            return true;
        }

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
