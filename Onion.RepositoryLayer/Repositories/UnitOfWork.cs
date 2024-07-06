using Onion.DomainLayer.DomainModels;
using Onion.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.RepositoryLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;

        public IUserRepo UserRepo { get; }

        public UnitOfWork(UserContext context)
        {
            _context = context;
            UserRepo = new UserRepo(context);
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