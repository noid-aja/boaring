using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsApp1.Models;

namespace WinFormsApp1.Helpers
{
    public static class UserContext
    {
        public static int IdUser { get; private set; }

        public static string NamaLengkap { get; private set; } = string.Empty;

        public static string Username { get; private set; } = string.Empty;

        public static List<string> Roles { get; private set; } = new();

        public static void SetUser(User user)
        {
            IdUser = user.Id();
            NamaLengkap = user.NamaLengkap;
            Username = user.Username;
            Roles = user.Roles;
        }

        public static bool HasRole(string role)
        {
            return Roles.Any(r =>
                r.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        public static void Clear()
        {
            IdUser = 0;
            NamaLengkap = string.Empty;
            Username = string.Empty;
            Roles = new List<string>();
        }
    }
}