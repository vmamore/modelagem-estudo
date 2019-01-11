using FluentValidation;
using FluentValidation.Results;

namespace VM.Domain.Entities
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }

        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool EhValido();

        public override bool Equals(object entidade)
        {
            var entidadeTmp = entidade as Entity<T>;

            if (ReferenceEquals(entidadeTmp, null)) return false;

            if (ReferenceEquals(this, entidadeTmp)) return true;

            if (GetType() != entidadeTmp.GetType()) return false;

            if (Id == 0 || entidadeTmp.Id == 0) return false;

            return Id == entidadeTmp.Id ;
        }

        public static bool operator ==(Entity<T> entidadeA, Entity<T> entidadeB)
        {
            if (ReferenceEquals(entidadeA, null) && ReferenceEquals(entidadeB, null)) return true;

            if (ReferenceEquals(entidadeA, null) || ReferenceEquals(entidadeB, null)) return false;

            return entidadeA.Equals(entidadeA);
        }

        public static bool operator !=(Entity<T> entidadeA, Entity<T> entidadeB)
        {
            return !(entidadeA == entidadeB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
