using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.DomainLayer.DomainModels;
using Onion.DomainLayer.Interfaces;
using Onion.RepositoryLayer.Repositories;
using Onion.RepositoryLayer;
using Onion.ServiceLayer.DTOModels;
using Onion.ServiceLayer.Interfaces;

namespace Onion.ServiceLayer.Services
{
    public class UserService : IUserService
    {
        UserContext _context = new UserContext();

        private readonly IUnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork(_context);
        }

        public List<UserDTO> getAllUsers()
        {
            var users = _unitOfWork.UserRepo.getAllUsers();
            List<UserDTO> userList = new List<UserDTO>();
            foreach(var user in users)
            {
                UserDTO userDTO = new UserDTO {
                    userID = user.userID,
                    username = user.username,
                    email = user.email,
                };
                userList.Add(userDTO);
            }
            return userList;
        }

        public void createUser(UserDTO userDTO)
        {
            var user = new Users
            {
                username = userDTO.username,
                email = userDTO.email,
                password = PasswordService.HashPassword(userDTO.password),
                confirmedPassword = PasswordService.HashPassword(userDTO.confirmedPassword)
            };
            _unitOfWork.UserRepo.createUser(user);
            _unitOfWork.complete();
        }

        public UserDTO findUser(int? id)
        {
            Users domainUser = _unitOfWork.UserRepo.findUser(id);
            if(domainUser == null)
            {
                return null;
            }
            return new UserDTO
            {
                userID = domainUser.userID,
                username = domainUser.username,
                email = domainUser.email
            };
        }

        public void editUser(UserDTO userDTO)
        {
            var user = _unitOfWork.UserRepo.findUser(userDTO.userID);
            if(user != null)
            {
                user.username = userDTO.username;
                user.email = userDTO.email;
                _unitOfWork.UserRepo.editUser(user);
                _unitOfWork.complete();
            }
        }

        public void deleteUser(int id)
        {
            _unitOfWork.UserRepo.deleteUser(id);
            _unitOfWork.complete();
        }
    }
}
