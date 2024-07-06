using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.DomainLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepo UserRepo { get; }
        int complete();
    }
}