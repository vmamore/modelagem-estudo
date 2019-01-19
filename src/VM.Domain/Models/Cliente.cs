using FluentValidation;
using FluentValidation.Results;
using System;
using VM.Domain.Entities;
using VM.Domain.ValueObjects;

namespace VM.Domain.Models
{
    public class Cliente : Entity<Cliente>
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Endereco Endereco { get; private set; }
        public Idade Idade { get; private set; }
        public Email Email { get; private set; }
        public CPF Cpf { get; private set; }

        public Cliente(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Ativo = true;
            DataCadastro = DateTime.Now;

            // TODO: Atribuição de VO
        }

        public Cliente() { }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }
        
        public bool AtribuirCpf(string cpfNumero) {

            var cpf = new CPF(cpfNumero);

            if (!cpf.EhValido())
                return false;

            this.Cpf = cpf;
            return true;
        }

        public bool AtribuirEmail(string enderecoEmail)
        {
            var email = new Email(enderecoEmail);

            if (!email.EhValido())
                return false;

            this.Email = email;
            return true;
        }

        public bool AtribuirIdade(DateTime dataNascimento)
        {
            var idade = new Idade(dataNascimento);

            if (!idade.EhValido())
                return false;

            this.Idade = idade;
            return true;
        }

        public bool AtribuirEndereco(string logradouro, string numero, string cidade, string estado, string bairro, string complemento, string cepNumero)
        {
            var endereco = new Endereco(logradouro, numero, cidade, estado, bairro, complemento, cepNumero);

            if (!endereco.EhValido())
                return false;

            this.Endereco = endereco;
            return true;
        }
        
        public void Inativar()
        {
            Ativo = false;
        }
        
        public void Ativar()
        {
            Ativo = true;
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
                .NotNull().WithMessage("É necessário informar Email correto!");

            RuleFor(c => c.Cpf)
                .NotNull().WithMessage("É necessário informar o CPF correto!");
        }
    }
}
