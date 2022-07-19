using Microsoft.AspNetCore.Mvc;
using SEESALoginFinal.DataAccess;
using SEESALoginFinal.Models;
using System.Security.Cryptography;
using System.Text;

namespace SEESALoginFinal.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData _userData;

        public UserController(IUserData userData)
        {
            _userData = userData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            List<UserModel> users = new List<UserModel>();

            users = _userData.GetUserByEmail(email);

            if (users.Count == 0)
            {
                return RedirectToAction("LoginFailed");
            }

            // Password validation
            byte[] source = Encoding.ASCII.GetBytes(password);
            byte[] hash = MD5.Create().ComputeHash(source);

            byte[] databaseHash = users[0].PasswordHash;

            if (hash.Length == databaseHash.Length)
            {
                int i = 0;
                while ((i < hash.Length) && (hash[i] == databaseHash[i]))
                {
                    i++;
                }
                if (i == hash.Length)
                {
                    return RedirectToAction("ViewAll");
                }
                else
                {
                    return RedirectToAction("LoginFailed");
                }
            }

            return RedirectToAction("LoginFailed");
        }

        public IActionResult ViewAll()
        {
            List<UserModel> users = new List<UserModel>();
            users = _userData.GetAllUsers();

            return View(users);
        }

        public IActionResult CreatePage()
        {
            return View();
        }

        public IActionResult Create(UserModel user, string password)
        {
            byte[] source = Encoding.ASCII.GetBytes(password);
            byte[] hash = MD5.Create().ComputeHash(source);

            user.PasswordHash = hash;

            _userData.InsertUser(user);

            return RedirectToAction("ViewAll");
        }

        public IActionResult Delete(int id)
        {
            _userData.DeleteUser(id);

            return RedirectToAction("ViewAll");
        }

        public IActionResult EditPage(int id)
        {
            List<UserModel> users = new List<UserModel>();

            users = _userData.GetUserById(id);

            return View(users[0]);
        }

        public IActionResult Edit(UserModel user, string password)
        {
            byte[] source = Encoding.ASCII.GetBytes(password);
            byte[] hash = MD5.Create().ComputeHash(source);

            user.PasswordHash = hash;

            _userData.UpdateUser(user);

            return RedirectToAction("ViewAll");
        }
    } 
}
