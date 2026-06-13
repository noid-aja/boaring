using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories;

namespace WinFormsApp1.Controllers
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public User GetProfilSaya()
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            return UserContext.CurrentUser!;
        }

        public void AdminDaftarkanInspektor(string namaLengkap, string username, string password, string? noTelp)
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Akses ditolak. Anda belum login.");

            if (!UserContext.IsAdmin())
                throw new UnauthorizedAccessException("Akses ditolak. Hanya Admin yang dapat mendaftarkan Inspektor.");

            if (string.IsNullOrWhiteSpace(namaLengkap) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Data calon inspektor tidak boleh kosong.");

            var user = new User
            {
                NamaLengkap = namaLengkap.Trim(),
                Username = username.Trim(),
                Password = password,
                NoTelp = noTelp?.Trim(),
                IsAktif = true
            };

            try
            {
                _userRepository.Register(user, "inspektor");
            }
            catch
            {
                throw new Exception("Admin gagal mendaftarkan Inspektor baru.");
            }
        }

        public bool HapusAkunSaya()
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            int currentIdUser = UserContext.CurrentUser!.IdUser;

            bool berhasil = _userRepository.SoftDeleteUser(currentIdUser);

            if (berhasil)
            {
                UserContext.Logout();
                return true;
            }
            else
            {
                throw new Exception("Gagal menghapus/menonaktifkan akun.");
            }
        }

        public void EditProfil(string namaLengkap, string? noTelp)
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            if (string.IsNullOrWhiteSpace(namaLengkap))
                throw new ArgumentException("Nama lengkap tidak boleh kosong.");

            if (noTelp != null && noTelp.Length < 10)
                throw new ArgumentException("Nomor telepon tidak valid.");

            if (!string.IsNullOrWhiteSpace(noTelp)
                && noTelp != UserContext.CurrentUser!.NoTelp
                && _userRepository.IsNoTelpTaken(noTelp))
                throw new ArgumentException("Nomor telepon sudah digunakan.");

            UserContext.CurrentUser!.NamaLengkap = namaLengkap.Trim();
            UserContext.CurrentUser!.NoTelp = noTelp?.Trim();

            bool berhasil = _userRepository.UpdateProfile(UserContext.CurrentUser!);
            if (!berhasil)
                throw new Exception("Gagal menyimpan perubahan profil.");
        }

        public void GantiPassword(string passwordLama, string passwordBaru, string konfirmasiPassword)
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            if (string.IsNullOrWhiteSpace(passwordLama))
                throw new ArgumentException("Password lama tidak boleh kosong.");

            if (passwordLama != UserContext.CurrentUser!.Password)
                throw new ArgumentException("Password lama salah.");

            if (string.IsNullOrWhiteSpace(passwordBaru))
                throw new ArgumentException("Password baru tidak boleh kosong.");

            if (passwordBaru.Length < 8)
                throw new ArgumentException("Password baru minimal 8 karakter.");

            if (passwordBaru == passwordLama)
                throw new ArgumentException("Password baru tidak boleh sama dengan password lama.");

            if (passwordBaru != konfirmasiPassword)
                throw new ArgumentException("Konfirmasi password tidak cocok.");

            bool berhasil = _userRepository.UpdatePassword(UserContext.CurrentUser!.IdUser, passwordBaru);

            if (!berhasil)
                throw new Exception("Gagal menyimpan password baru.");

            UserContext.CurrentUser!.Password = passwordBaru;
        }

        public void TambahRoleSaya(string role)
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            if (role != "petani" && role != "pembeli")
                throw new ArgumentException("Kamu hanya bisa menambahkan role petani atau pembeli.");

            if (UserContext.CurrentUser!.IsInRole(role))
                throw new ArgumentException($"Kamu sudah memiliki role {role}.");

            bool berhasil = _userRepository.AddRole(UserContext.CurrentUser!.IdUser, role);

            if (!berhasil)
                throw new Exception("Gagal menambahkan role.");

            int idRoleBaru = role.Equals("petani", StringComparison.OrdinalIgnoreCase) ? 2 : 3;
            UserContext.CurrentUser!.Roles.Add(new Userrole(UserContext.CurrentUser!.IdUser, idRoleBaru, role));
        }

        public void HapusRoleSaya(string role)
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            if (role != "petani" && role != "pembeli")
                throw new ArgumentException("Kamu hanya bisa menghapus role petani atau pembeli.");

            if (!UserContext.CurrentUser!.IsInRole(role))
                throw new ArgumentException($"Kamu tidak memiliki role {role}.");

            if (UserContext.CurrentUser!.Roles.Count <= 1)
                throw new ArgumentException("Kamu harus memiliki minimal 1 role aktif.");

            bool berhasil = _userRepository.RemoveRole(UserContext.CurrentUser!.IdUser, role);

            if (!berhasil)
                throw new Exception("Gagal menghapus role.");

            var roleTarget = UserContext.CurrentUser!.Roles
                .FirstOrDefault(r => r.NamaRole.Equals(role, StringComparison.OrdinalIgnoreCase));

            if (roleTarget != null)
                UserContext.CurrentUser!.Roles.Remove(roleTarget);
        }

        public List<string> GetRoleSaya()
        {
            if (!UserContext.IsLoggedIn())
                throw new UnauthorizedAccessException("Belum login.");

            return UserContext.CurrentUser!.Roles.Select(r => r.NamaRole).ToList();
        }
    }
}