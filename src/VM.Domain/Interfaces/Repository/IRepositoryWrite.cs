using System;
using VM.Domain.Entities;

namespace VM.Domain.Interfaces.Repository
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        TEntity Adicionar(TEntity entidade);
        TEntity Atualizar(TEntity entidade);
        void Remover(int id);
        int SaveChanges();
    }
}
