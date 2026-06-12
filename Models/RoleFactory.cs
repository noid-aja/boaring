using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models.Roles;

namespace WinFormsApp1.Models
{
    public static class RoleFactory
    {
        public static RoleUser Create(User user, string namaRole)
        {
            switch (namaRole.ToLower())
            {
                case "admin":
                    return new AdminRole(user);

                case "petani":
                    return new PetaniRole(user);

                case "pembeli":
                    return new PembeliRole(user);

                case "inspektor":
                    return new InspektorRole(user);

                default:
                    throw new ArgumentException("Role tidak dikenali: " + namaRole);
            }
        }
    }
}