﻿namespace VM.Domain.ValueObjects
{
    public class CPF : ValueObject<CPF>
    {
        public string Numero { get; private set; }

        public CPF(string cpfNumero)
        {
            Numero = cpfNumero;
        }

        public override bool EhValido()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        private bool Validar()
        {
            if (Numero.Length > 11)
                return false;

            while (Numero.Length != 11)
                Numero = '0' + Numero;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (Numero[i] != Numero[0])
                    igual = false;

            if (igual || Numero == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(Numero[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        protected override bool EqualsCore(CPF other)
        {
            return this.Numero == other.Numero;
        }

        protected override int GetHashCodeCore()
        {
            return this.Numero.GetHashCode();
        }
    }
}
