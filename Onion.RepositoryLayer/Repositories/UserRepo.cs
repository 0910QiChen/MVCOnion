using System.Collections.Generic;
using Onion.DomainLayer.DomainModels;
using Onion.DomainLayer.Interfaces;

namespace Onion.RepositoryLayer.Repositories
{
    public class UserRepo : GenericRepo<Users>, IUserRepo
    {
        private readonly GenericRepo<Users> _usersRepo;

        public UserRepo(UserContext context) : base(context)
        {
            _usersRepo = new GenericRepo<Users>(context);
        }

        public IEnumerable<Users> getAllUsers()
        {
            return _usersRepo.getAll();
        }

        public void createUser(Users user)
        {
            _usersRepo.add(user);
        }

        public Users findUser(int? id)
        {
            return _usersRepo.getByID(id);
        }

        public void editUser(Users user)
        {
            _usersRepo.update(findUser(user.userID));
        }

        public void deleteUser(int id)
        {
            _usersRepo.delete(findUser(id));
        }
    }
}