﻿using System;
using VM.Infra.Data.Context;
using VM.Infra.Data.Interfaces;

namespace VM.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClienteContext _context;
        private bool _disposed;

        public UnitOfWork(ClienteContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
