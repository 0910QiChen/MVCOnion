using Onion.ServiceLayer.DTOModels;
using System.Collections.Generic;

namespace Onion.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> getAllUsers();
        void createUser(UserDTO user);

        UserDTO findUser(int? id);

        void editUser(UserDTO user);

        void deleteUser(int id);
    }
}