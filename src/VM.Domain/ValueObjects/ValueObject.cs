using FluentValidation;
using FluentValidation.Results;

namespace VM.Domain.ValueObjects
{
    public abstract class ValueObject<T> : AbstractValidator<T> where T : ValueObject<T>
    {
        public ValueObject()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool EhValido();

        protected abstract bool EqualsCore(T other);
        
        public override bool Equals(object objetoDeValor)
        {
            var objDeValor = objetoDeValor as T;

            if (ReferenceEquals(objDeValor, null))
                return false;

            return EqualsCore(objDeValor);
        }
        
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> objetoA,
            ValueObject<T> objetoB)
        {
            if (ReferenceEquals(objetoA, null) && ReferenceEquals(objetoB, null))
                return true;

            if (ReferenceEquals(objetoA, null) || ReferenceEquals(objetoB, null))
                return false;

            return objetoA.Equals(objetoB);
        }

        public static bool operator !=(ValueObject<T> objetoA,
            ValueObject<T> objetoB)
        {
            return !(objetoA == objetoB);
        }
    }
}
