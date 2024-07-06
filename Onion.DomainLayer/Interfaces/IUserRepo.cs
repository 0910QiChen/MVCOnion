using Onion.DomainLayer.DomainModels;
using System.Collections.Generic;

namespace Onion.DomainLayer.Interfaces
{
    public interface IUserRepo : IGenericRepo<Users>
    {
        IEnumerable<Users> getAllUsers();

        void createUser(Users user);

        Users findUser(int? id);

        void editUser(Users user);

        void deleteUser(int id);
    }
}