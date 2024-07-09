using Onion.DomainLayer.Interfaces;
using System;

namespace Onion.RepositoryLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;

        public IUserRepo UserRepo { get; }

        public UnitOfWork(UserContext context)
        {
            _context = context;
            UserRepo = new UserRepo(_context);
        }

        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}