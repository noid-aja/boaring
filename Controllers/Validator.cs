using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Controllers
{
    static class Validator
    {
        public static bool ApakahKosong(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ApakahAngka(string input)
        {
            if (!int.TryParse(input, out _))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ApakahPanjang(int min, string input, int? max = null)
        {
            if (max == null)
            {
                int panjangInput = input.Length;
                if (panjangInput < min)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                int panjangInput = input.Length;
                if (panjangInput < min || panjangInput > max)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool ApakahHurufdanAngka(string input)
        {
            if (input.All(ch => char.IsLetterOrDigit(ch)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ApakahEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
