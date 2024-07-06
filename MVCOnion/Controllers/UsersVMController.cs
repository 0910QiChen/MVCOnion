using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCOnion.Models;
using Onion.ServiceLayer.DTOModels;
using Onion.ServiceLayer.Interfaces;
using Onion.ServiceLayer.Services;

namespace MVCOnion.Controllers
{
    public class UsersVMController : Controller
    {
        public IUserService userService;

        public UsersVMController()
        {
            userService = new UserService();
        }

        public ActionResult Index()
        {
            var users = userService.getAllUsers();
            List<UsersVM> userList = new List<UsersVM>();
            foreach(var user in users)
            {
                UsersVM viewUser = new UsersVM();
                viewUser.userID = user.userID;
                viewUser.username = user.username;
                viewUser.email = user.email;
                userList.Add(viewUser);
            }
            return View(userList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDTO = userService.findUser(id);
            UsersVM usersVM = new UsersVM
            {
                username = userDTO.username,
                email = userDTO.email,
            };
            if (usersVM == null)
            {
                return HttpNotFound();
            }
            return View(usersVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,username,email,password,confirmedPassword")] UsersVM usersVM)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO()
                {
                    username = usersVM.username,
                    email = usersVM.email,
                    password = usersVM.password,
                    confirmedPassword = usersVM.confirmedPassword,
                };
                userService.createUser(user);
                return RedirectToAction("Index");
            }
            return View(usersVM);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = userService.findUser(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            var usersVM = new UsersVM()
            {
                userID = userDTO.userID,
                username = userDTO.username,
                email = userDTO.email,
            };
            return View(usersVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,email")] UsersVM usersVM)
        {
            var userDTO = new UserDTO
            {
                username = usersVM.username,
                email = usersVM.email,
            };
            userService.editUser(userDTO);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = userService.findUser(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            var usersVM = new UsersVM
            {
                userID = userDTO.userID,
                username = userDTO.username,
                email = userDTO.email,
            };
            return View(usersVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userService.deleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
