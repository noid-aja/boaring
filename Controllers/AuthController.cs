using System;
using WinFormsApp1.Models;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Controllers
{
    public class AuthController
    {
        private readonly WinFormsApp1.Repositories.UserRepository _repo;

        public AuthController()
        {
            _repo = new WinFormsApp1.Repositories.UserRepository();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username dan password tidak boleh kosong.");

            var user = _repo.Login(username.Trim(), password);
            if (user == null)
                throw new UnauthorizedAccessException("Username atau password salah.");

            return user;
        }
    }
}
