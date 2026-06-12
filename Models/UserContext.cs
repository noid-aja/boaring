using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp1.Models;

namespace WinFormsApp1.Helpers
{
    public static class UserContext
    {
        public static User? CurrentUser { get; private set; }

        public static void Login(User user) => CurrentUser = user;
        public static void Logout() => CurrentUser = null;
        public static void SetUser(User user) => CurrentUser = user;
        public static void Clear() => CurrentUser = null;

        public static bool IsLoggedIn => CurrentUser != null;
        public static int IdUser => CurrentUser?.IdUser ?? 0;

        public static bool IsAdmin => CurrentUser?.IsInRole("admin") == true;
        public static bool IsPetani => CurrentUser?.IsInRole("petani") == true;
        public static bool IsPembeli => CurrentUser?.IsInRole("pembeli") == true;
        public static bool IsInspektor => CurrentUser?.IsInRole("inspektor") == true;

        public static bool HasAnyRole(params string[] roles)
            => roles.Any(r => CurrentUser?.IsInRole(r) == true);

        public static void RequireRole(string role)
        {
            if (CurrentUser == null)
                throw new UnauthorizedAccessException("Belum login.");

            if (!CurrentUser.IsInRole(role))
                throw new UnauthorizedAccessException($"Akses ditolak. Role '{role}' dibutuhkan.");
        }

        public static List<string> GetRoleNames()
            => CurrentUser?.Roles.Select(r => r.NamaRole).ToList() ?? new List<string>();
    }
}
