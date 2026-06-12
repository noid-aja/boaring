using System;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories;

namespace WinFormsApp1.Controllers
{
    public class AuthController
    {
        private readonly UserRepository _repo;

        public AuthController()
        {
            _repo = new UserRepository();
        }

        public void Register(
            string namaLengkap,
            string username,
            string password,
            string konfirmasiPassword,
            string noTelp,
            string role)
        {
            if (string.IsNullOrWhiteSpace(namaLengkap))
                throw new ArgumentException("Nama lengkap tidak boleh kosong.");

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username tidak boleh kosong.");

            if (username.Length < 4)
                throw new ArgumentException("Username minimal 4 karakter.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password tidak boleh kosong.");

            if (password.Length < 8)
                throw new ArgumentException("Password minimal 8 karakter.");

            if (password != konfirmasiPassword)
                throw new ArgumentException("Konfirmasi password tidak cocok.");

            role = role.Trim().ToLower();
            if (role != "petani" && role != "pembeli")
                throw new ArgumentException("Role hanya boleh petani atau pembeli.");

            User user = new User
            {
                NamaLengkap = namaLengkap.Trim(),
                Username = username.Trim(),
                Password = password,
                NoTelp = string.IsNullOrWhiteSpace(noTelp) ? null : noTelp.Trim(),
                IsAktif = true
            };

            _repo.Register(user, role);
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
