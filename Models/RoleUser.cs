using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public abstract class RoleUser
    {
        protected User User { get; }

        protected RoleUser(User user)
        {
            User = user;
        }

        public abstract string NamaRole { get; }

        public abstract string JudulDashboard { get; }

        public abstract List<string> GetMenuAkses();

        public virtual bool BisaAksesMenu(string namaMenu)
        {
            return GetMenuAkses().Contains(namaMenu);
        }
    }
}