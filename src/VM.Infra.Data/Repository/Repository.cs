using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VM.Domain.Entities;
using VM.Domain.Interfaces.Repository;
using VM.Infra.Data.Context;

namespace VM.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity<TEntity>, new()
    {
        protected ClienteContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(ClienteContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public TEntity ObterPor(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity Adicionar(TEntity entidade)
        {
            var objRetorno = DbSet.Add(entidade);
            return objRetorno.Entity;
        }

        public TEntity Atualizar(TEntity entidade)
        {
            var entry = Db.Entry(entidade);
            DbSet.Attach(entidade);
            entry.State = EntityState.Modified;
            return entidade;
        }

        public void Remover(int id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
