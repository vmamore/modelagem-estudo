using FluentValidation;
using FluentValidation.Results;
using System;
using VM.Domain.Entities;
using VM.Domain.ValueObjects;

namespace VM.Domain.Models
{
    public class Cliente : Entity<Cliente>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public Endereco Endereco { get; set; }
        public Idade Idade { get; set; }
        public Email Email { get; set; }
        public CPF Cpf { get; set; }

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
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente precisa ser fornecido!")
                .Length(3, 150).WithMessage("O nome do cliente precisa ter entre 3 e 150 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty()
                .WithMessage("O sobrenome do cliente precisa ser fornecido!")
                .Length(3, 150).WithMessage("O sobrenome do cliente precisa ter entre 3 e 150 caracteres");

            RuleFor(c => c.DataCadastro)
                .NotNull().WithMessage("Data de cadastro inválida, contate o suporte!");

            RuleFor(c => c.Idade)
                .NotNull().WithMessage("É necessário informar idade!");

            RuleFor(c => c.Email)
                .NotNull().WithMessage("É necessário informar email!");

            RuleFor(c => c.Cpf)
                .NotNull().WithMessage("É necessário informar cpf!");
        }
    }
}
